using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CableManager : MonoBehaviour
{
    public DeviceComponent[] allCables;
    public Dictionary<string, DeviceComponent> availableComponents;

    void Start()
    {
        availableComponents = GameManager.GetAllComponents();

        SetAvailableCables();
    }

    private void SetAvailableCables()
    {
        for (int i = 0; i < allCables.Length; i++)
        {
            if (!availableComponents[allCables[i].ComponentName].IsAvailabe)
            {
                allCables[i].gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {

    }
}
