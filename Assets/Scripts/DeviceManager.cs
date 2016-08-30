using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeviceManager : MonoBehaviour {

    public DeviceComponent[] allDevices;
    public Dictionary<string, DeviceComponent> availableComponents;

    void Start()
    {
        availableComponents = GameManager.GetAllDevices();

        SetAvailableDevices();
    }

    private void SetAvailableDevices()
    {
        for (int i = 0; i < allDevices.Length; i++)
        {
            if (!availableComponents[DeviceComponentHelper.DeviceName(allDevices[i].deviceType)].IsAvailabe)
            {
                allDevices[i].gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {

    }
}
