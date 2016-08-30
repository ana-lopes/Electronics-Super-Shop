using UnityEngine;
using System.Collections;

public class DeviceComponent : MonoBehaviour {

    public DeviceComponentHelper.DeviceType deviceType;
    public string deviceName;
    public Sprite image;
    public float price;
    public Sprite firstEntrance;
    public Sprite secondEntrance;

    public bool _isAvailable;

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
