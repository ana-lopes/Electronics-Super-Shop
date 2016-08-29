using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DeviceComponent))]
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
        _componentName = GetComponent<DeviceComponent>().ComponentName;
    }
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colliderObj = col.gameObject;

        if(colliderObj.tag == EntranceType())
        {
            if(colliderObj.GetComponent<DeviceComponent>() != null && colliderObj.GetComponent<DeviceComponent>().ComponentName == _componentName)
            {
                //TODO: something saying good job
                //TODO: something about the game logic that is missing... oh ya send info to montage manager
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
