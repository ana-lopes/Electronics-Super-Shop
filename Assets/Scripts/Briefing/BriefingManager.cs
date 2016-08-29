using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class BriefingManager
{
    private static List<Briefing> _briefingList = new List<Briefing>();
    private static List<GameObject> _prefabList = new List<GameObject>();
    
    public static List<Briefing> GetAllBriefings()
    {
        _prefabList = new List<GameObject>();
        _prefabList.AddRange(Resources.LoadAll<GameObject>("Briefings"));

        foreach (GameObject g in _prefabList)
        {
            _briefingList.Add(g.GetComponentInChildren<BriefingInfo>(true).GetBriefing());
        }

        return _briefingList;
    }

    public static Briefing GetRandomBriefing()
    {
        int random = Random.Range(0, _briefingList.Count-1);

        return _briefingList[random];
    }
}
