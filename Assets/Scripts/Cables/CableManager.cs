using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CableManager : MonoBehaviour
{
    public CableComponent[] allCables;
    public Dictionary<string, CableComponent> availableComponents;

    void Start()
    {
        availableComponents = GameManager.GetAllCables();

        SetAvailableCables();
    }

    private void SetAvailableCables()
    {
        for (int i = 0; i < allCables.Length; i++)
        {
            if (!availableComponents[DeviceComponentHelper.ComponentName(allCables[i].componentType)].IsAvailabe)
            {
                allCables[i].gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {

    }
}
