using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class GameManager
{
    private static Dictionary<string, DeviceComponent> _componentList = new Dictionary<string, DeviceComponent>();
    private static float _totalMoney;
    private static List<GameObject> _prefabList;
    private static float _timerState = 30;
    private static Briefing _briefing;

    private static GameObject _firsDevicePrefab;
    private static GameObject _secondDevicePrefab;

    private static List<GameObject> _selectedComponents;

    static GameManager()
    {
        GetAllComponents();
        BriefingManager.GetAllBriefings();
    }

    public static void SetMoney(float value)
    {
        _totalMoney = value;
    }

    public static float GetTotalMoney()
    {
        return _totalMoney;
    }

    public static List<GameObject> GetSelectedItems()
    {
        return _selectedComponents;
    }

    public static void AddItemSelection(DeviceComponent component)
    {
        if(_selectedComponents == null || _selectedComponents.Count == 0)
        {
            _selectedComponents = new List<GameObject>();
        }

        foreach (GameObject g in _prefabList)
        {
            //TODO: fix this cuz tis bad
            if (g.name.Contains(component.ComponentName) && !_selectedComponents.Contains(g))
            {
                _selectedComponents.Add(g);
                break;
            }
        }
    }

    private static void SetPrefabList()
    {
        _prefabList = new List<GameObject>();
        _prefabList.AddRange(Resources.LoadAll<GameObject>("Components"));
    }

    public static Dictionary<string, DeviceComponent> GetAllComponents()
    {
        SetPrefabList();

        foreach (GameObject g in _prefabList)
        {
            DeviceComponent componentComponent = g.GetComponentInChildren<DeviceComponent>(true);
            if (!_componentList.ContainsKey(componentComponent.ComponentName))
            {
                _componentList.Add(componentComponent.ComponentName, componentComponent);
            }
        }

        return _componentList;
    }

    public static void ResetSelectedItens()
    {
        _selectedComponents = new List<GameObject>();
    }

    public static List<GameObject> GetAllGameObjectComponents()
    {
        SetPrefabList();

        return _prefabList;
    }

    public static List<GameObject> GetAllAvailableComponents()
    {
        List<GameObject> list = new List<GameObject>();

        foreach (DeviceComponent c in _componentList.Values)
        {
            if (c.IsAvailabe)
            {
                list.Add(c.gameObject);
            }
        }

        return list;
    }

    public static DeviceComponent GetComponent(string key)
    {
        return _componentList[key];
    }

    public static void UpdateComponentAvailability(string key, bool available)
    {
        _componentList[key].IsAvailabe = available;
    }

    public static Briefing GetSetBriefing
    {
        get { return _briefing; }
        set { _briefing = value; }
    }

    public static Briefing GetRandomBriefing()
    {
        return BriefingManager.GetRandomBriefing();
    }

    public static float TimerState
    {
        get { return _timerState; }
        set { _timerState = value; }
    }
}
