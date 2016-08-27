using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WhatAmI))]
public class CableEntrance : MonoBehaviour {

    public Entrance entranceType;
    public enum Entrance
    {
        inEntrance,
        outEntrance,
    }

    private string _componentName;
    
    void Awake()
    {
        _componentName = GetComponent<WhatAmI>().ComponentName;
    }
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colliderObj = col.gameObject;

        if(colliderObj.tag == EntranceType())
        {
            if(colliderObj.GetComponent<WhatAmI>() != null && colliderObj.GetComponent<WhatAmI>().ComponentName == _componentName)
            {
                colliderObj.GetComponent<DragCable>().HasConnection();
            }

            else
            {
                //TODO: something happens
            }
        }
    }

    private string EntranceType()
    {
        switch(entranceType)
        {
            case Entrance.inEntrance:
                return "cable-in";

            case Entrance.outEntrance:
                return "cable-out";

            default:
                return "";
        }
    }

}
