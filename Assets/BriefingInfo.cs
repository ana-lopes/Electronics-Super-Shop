using UnityEngine;
using System.Collections;

public class BriefingInfo : MonoBehaviour {

    public string title;
    public Sprite image;
    public Sprite[] entrances;
    public float price;

    Briefing briefing;

    void Start()
    {
        briefing = new Briefing(title, image, entrances, price);

        GameManager.SetBriefing(briefing);
    }
}

public class Briefing
{
    public string title;
    public Sprite image;
    public Sprite[] entrances;
    public float price;

    public Briefing(string title, Sprite image, Sprite[] entrances, float price)
    {
        this.title = title;
        this.image = image;
        this.entrances = entrances;
        this.price = price;
    }
}
