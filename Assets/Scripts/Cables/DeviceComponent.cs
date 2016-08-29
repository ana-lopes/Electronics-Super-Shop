using UnityEngine;
using System.Collections;

public class DeviceComponent : MonoBehaviour {

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
        scart,
        midi,
        mini_dvi,
        thunderbolt,
        trs,
        trs35mm,
        xlr
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
                case ComponentType.midi:
                    return "midi";
                case ComponentType.mini_dvi:
                    return "mini-dvi";
                case ComponentType.thunderbolt:
                    return "thunderbolt";
                case ComponentType.trs:
                    return "trs";
                case ComponentType.trs35mm:
                    return "trs-35mm";
                case ComponentType.xlr:
                    return "xlr";
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
