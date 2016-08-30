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

    public enum DeviceType
    {
        camCorder,
        cassete,
        computer_crt,
        crt,
        crt_plus,
        dibox,
        dreamweaver,
        dvd1,
        dvd2,
        dvd3,
        funstation,
        handycam,
        hi8,
        minidisc,
        minidisc_player,
        minidv,
        tv_4k,
        tv_lcd,
        tv_plasma,
        tv_tft,
        vhs1,
        vhs2,
        vhs3,
        vhs_camera,
        vhs_tape,
        walkman,
        wiird,
        zbox
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

    public static string DeviceName(DeviceType device)
    {
        switch(device)
        {
            case DeviceType.camCorder:
                return "cam recorder";
            case DeviceType.cassete:
                return "cassete";
            case DeviceType.computer_crt:
                return "computer crt";
            case DeviceType.crt:
                return "crt";
            case DeviceType.crt_plus:
                return "crt plus";
            case DeviceType.dibox:
                return "di box";
            case DeviceType.dreamweaver:
                return "dreamweaver";
            case DeviceType.dvd1:
                return "dvd 1";
            case DeviceType.dvd2:
                return "dvd 2";
            case DeviceType.dvd3:
                return "dvd 3";
            case DeviceType.funstation:
                return "funstation";
            case DeviceType.handycam:
                return "handycam";
            case DeviceType.hi8:
                return "hi8";
            case DeviceType.minidisc:
                return "minidisc";
            case DeviceType.minidisc_player:
                return "minisc player";
            case DeviceType.minidv:
                return "minidv";
            case DeviceType.tv_4k:
                return "tv 4k";
            case DeviceType.tv_lcd:
                return "tv lcd";
            case DeviceType.tv_plasma:
                return "tv plasma";
            case DeviceType.tv_tft:
                return "tv tft";
            case DeviceType.vhs1:
                return "vhs 1";
            case DeviceType.vhs2:
                return "vhs 2";
            case DeviceType.vhs3:
                return "vhs 3";
            case DeviceType.vhs_camera:
                return "vhs camera";
            case DeviceType.vhs_tape:
                return "vhs tape";
            case DeviceType.walkman:
                return "walkman";
            case DeviceType.wiird:
                return "wiird";
            case DeviceType.zbox:
                return "zbox";
            default:
                return "";
        }
    }

}
