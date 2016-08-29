using UnityEngine;
using System.Collections;

public class BriefingInfo : MonoBehaviour {

    public Sprite firstDevice;
    public Sprite secondDevice;
    public Sprite entrance;
    public float price;
    public float totalTime;

    [Header("Prefabs")]
    public GameObject firstDevicePrefab;
    public GameObject secondDevicePrefab;

    private Briefing _briefing;
    
    public Briefing GetBriefing()
    {
        _briefing = new Briefing(firstDevice, secondDevice, entrance, price, totalTime, firstDevicePrefab, secondDevicePrefab);
        return _briefing;
    }
}

public class Briefing
{
    public Sprite firstDevice;
    public Sprite secondDevice;
    public Sprite entrance;
    public float price;
    public float totalTime;

    public GameObject firstDevicePrefab;
    public GameObject secondDevicePrefab;

    public Briefing(Sprite firstDevice, Sprite secondDevice, Sprite entrance, float price, float totalTime, GameObject firstDevicePrefab, GameObject secondDevicePrefab)
    {
        this.firstDevice = firstDevice;
        this.secondDevice = secondDevice;
        this.entrance = entrance;
        this.price = price;
        this.totalTime = totalTime;

        this.firstDevicePrefab = firstDevicePrefab;
        this.secondDevicePrefab = secondDevicePrefab;
    }
}
