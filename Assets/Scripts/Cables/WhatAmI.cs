using UnityEngine;
using System.Collections;

public class WhatAmI : MonoBehaviour {
    public ComponentType componennt;

    public enum ComponentType
    {
        vga,
        hdmi,
    }

    public string ComponentName
    {
        get
        {
            switch (componennt)
            {
                case ComponentType.vga:
                    return "vga";
                default:
                    return "";
            }
        }
    }
}
