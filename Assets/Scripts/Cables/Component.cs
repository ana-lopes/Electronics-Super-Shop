using UnityEngine;
using System.Collections;

public class Component : MonoBehaviour {

    public ComponentType componennt;
    public string description;
    public Sprite image;
    public float price;

    public bool _isAvailable;

    public enum ComponentType
    {
        vga,
        hdmi,
        rca,
        dvi,
        s_video,
        scart
    }

    public string ComponentName
    {
        get
        {
            switch (componennt)
            {
                case ComponentType.vga:
                    return "vga";
                case ComponentType.hdmi:
                    return "hdmi";
                case ComponentType.rca:
                    return "rca";
                case ComponentType.dvi:
                    return "dvi";
                case ComponentType.s_video:
                    return "s-video";
                case ComponentType.scart:
                    return "scart";
                default:
                    return "";
            }
        }
    }

    public bool IsAvailabe
    {
        get { return _isAvailable; }
        set { _isAvailable = value; }
    }

    public float GetPrice()
    {
        return price;
    }
}
