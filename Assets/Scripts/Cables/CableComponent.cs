using UnityEngine;
using System.Collections;

public class CableComponent : MonoBehaviour {

    public DeviceComponentHelper.ComponentType componentType;
    public string cableName;
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
