using UnityEngine;
using System.Collections;

public class DeviceComponentHelper : MonoBehaviour
{
    public enum ComponentType
    {
        dvi,
        hdmi,
        midi,
        mini_dvi,
        rca,
        s_video,
        scart,
        thunderbolt,
        trs,
        trs35mm,
        vga,
        xlr
    }

    public static string ComponentName(ComponentType component)
    {
        switch (component)
        {
            case ComponentType.dvi:
                return "dvi";
            case ComponentType.hdmi:
                return "hdmi";
            case ComponentType.midi:
                return "midi";
            case ComponentType.mini_dvi:
                return "mini-dvi";
            case ComponentType.rca:
                return "rca";
            case ComponentType.s_video:
                return "s-video";
            case ComponentType.scart:
                return "scart";
            case ComponentType.thunderbolt:
                return "thunderbolt";
            case ComponentType.trs:
                return "trs";
            case ComponentType.trs35mm:
                return "trs-35mm";
            case ComponentType.vga:
                return "vga";
            case ComponentType.xlr:
                return "xlr";
            default:
                return "";
        }

    }

}
