using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameManager
{
    private static Dictionary<string, Component> _componentList = new Dictionary<string, Component>();
    private static float _totalMoney;
    private static List<GameObject> _prefabList;
    private static float _timerState;
    private static Briefing _briefing;

    private static GameObject _firsDevicePrefab;
    private static GameObject _secondDevicePrefab;

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

    public static Dictionary<string, Component> GetAllComponents()
    {
        _prefabList = new List<GameObject>();
        _prefabList.AddRange(Resources.LoadAll<GameObject>("Components"));

        foreach (GameObject g in _prefabList)
        {
            Component componentComponent = g.GetComponentInChildren<Component>(true);
            if (!_componentList.ContainsKey(componentComponent.ComponentName))
            {
                _componentList.Add(componentComponent.ComponentName, componentComponent);
            }
        }
        
        return _componentList;
    }

    public static List<GameObject> GetAllGameObjectComponents()
    {
        return _prefabList;
    }

    public static List<GameObject> GetAllAvailableComponents()
    {
        List<GameObject> list = new List<GameObject>();

        foreach (Component c in _componentList.Values)
        {
            if (c.IsAvailabe)
            {
                list.Add(c.gameObject);
            }
        }

        return list;
    }

    public static Component GetComponent(string key)
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
