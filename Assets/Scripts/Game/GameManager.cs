using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class GameManager
{
    private static Dictionary<string, CableComponent> _cableList = new Dictionary<string, CableComponent>();
    private static Dictionary<string, DeviceComponent> _deviceList = new Dictionary<string, DeviceComponent>();
    
    private static List<GameObject> _cablePrefabs;
    private static List<GameObject> _devicePrefabs;

    private static Briefing _briefing;

    private static GameObject _firsDevicePrefab;
    private static GameObject _secondDevicePrefab;

    private static List<GameObject> _selectedCables;
    private static List<GameObject> _selectedDevices;

    private static float _totalMoney = 10;
    private static float _timerState = 30;

    public static int numberOfConections = 0;

    static GameManager()
    {
        GetAllCables();
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

    public static List<GameObject> GetSelectedCables()
    {
        return _selectedCables;
    }

    public static List<GameObject> GetSelectedDevices()
    {
        return _selectedDevices;
    }

    public static void AddCableSelection(CableComponent component)
    {
        if (_selectedCables == null || _selectedCables.Count == 0)
        {
            _selectedCables = new List<GameObject>();
        }

        foreach (GameObject g in _cablePrefabs)
        {
            if ((DeviceComponentHelper.ComponentName(g.GetComponentInChildren<CableComponent>(true).componentType) ==
                DeviceComponentHelper.ComponentName(component.componentType)) && !_selectedCables.Contains(g))
            {
                _selectedCables.Add(g);
                break;
            }
        }
    }

    public static void AddDeviceSelection(DeviceComponent component)
    {
        if (_selectedDevices == null || _selectedDevices.Count == 0)
        {
            _selectedDevices = new List<GameObject>();
        }

        foreach (GameObject g in _devicePrefabs)
        {
            if ((DeviceComponentHelper.DeviceName(g.GetComponentInChildren<DeviceComponent>(true).deviceType) ==
                DeviceComponentHelper.DeviceName(component.deviceType)) && !_selectedDevices.Contains(g))
            {
                _selectedDevices.Add(g);
                break;
            }
        }
    }

    private static void SetCablePrefabList()
    {
        _cablePrefabs = new List<GameObject>();
        _cablePrefabs.AddRange(Resources.LoadAll<GameObject>("Components/Cables"));
    }

    private static void SetDevicePrefabList()
    {
        _devicePrefabs = new List<GameObject>();
        _devicePrefabs.AddRange(Resources.LoadAll<GameObject>("Components/Devices"));
    }

    public static Dictionary<string, CableComponent> GetAllCables()
    {
        SetCablePrefabList();

        foreach (GameObject g in _cablePrefabs)
        {
            CableComponent componentComponent = g.GetComponentInChildren<CableComponent>(true);
            if (!_cableList.ContainsKey(DeviceComponentHelper.ComponentName(componentComponent.componentType)))
            {
                _cableList.Add(DeviceComponentHelper.ComponentName(componentComponent.componentType), componentComponent);
            }
        }

        return _cableList;
    }

    public static Dictionary<string, DeviceComponent> GetAllDevices()
    {
        SetDevicePrefabList();

        foreach (GameObject g in _devicePrefabs)
        {
            DeviceComponent componentComponent = g.GetComponentInChildren<DeviceComponent>(true);
            if (!_deviceList.ContainsKey(DeviceComponentHelper.DeviceName(componentComponent.deviceType)))
            {
                _deviceList.Add(DeviceComponentHelper.DeviceName(componentComponent.deviceType), componentComponent);
            }
        }

        return _deviceList;
    }

    public static void ResetSelectedItens()
    {
        _selectedCables = new List<GameObject>();
        _selectedDevices = new List<GameObject>();
    }

    public static List<GameObject> GetAllCablesGameObjects()
    {
        SetCablePrefabList();

        return _cablePrefabs;
    }

    public static List<GameObject> GetAllDeviceGameObjects()
    {
        SetDevicePrefabList();

        return _devicePrefabs;
    }

    public static List<GameObject> GetAllAvailableCables()
    {
        List<GameObject> list = new List<GameObject>();

        foreach (CableComponent c in _cableList.Values)
        {
            if (c.IsAvailabe)
            {
                list.Add(c.gameObject);
            }
        }

        return list;
    }

    public static List<GameObject> GetAllAvailableDevices()
    {
        List<GameObject> list = new List<GameObject>();

        foreach (DeviceComponent c in _deviceList.Values)
        {
            if (c.IsAvailabe)
            {
                list.Add(c.gameObject);
            }
        }

        return list;
    }

    public static CableComponent GetCableComponent(string key)
    {
        return _cableList[key];
    }

    public static DeviceComponent GetDeviceComponent(string key)
    {
        return _deviceList[key];
    }

    public static void UpdateCableAvailability(string key, bool available)
    {
        _cableList[key].IsAvailabe = available;
    }

    public static void UpdateDeviceAvailability(string key, bool available)
    {
        _deviceList[key].IsAvailabe = available;
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
