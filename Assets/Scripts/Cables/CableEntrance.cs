using UnityEngine;
using System.Collections;

public class CableEntrance : MonoBehaviour
{
    public DeviceComponentHelper.ComponentType componentType;
    public Entrance entranceType;
    public enum Entrance
    {
        inEntrance,
        outEntrance,
    }

    private string _componentName;

    void Awake()
    {
        _componentName = DeviceComponentHelper.ComponentName(componentType);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colliderObj = col.gameObject;

        if (colliderObj.tag == EntranceType())
        {
            if (colliderObj.GetComponent<DeviceComponent>() != null && DeviceComponentHelper.ComponentName(colliderObj.GetComponent<DeviceComponent>().componentType) == _componentName)
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
        switch (entranceType)
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
