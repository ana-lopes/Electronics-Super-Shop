using UnityEngine;
using System.Collections;

public class DeviceSpawn : MonoBehaviour {

    void Awake()
    {
        if (GameManager.GetSelectedDevices() != null)
        {
            foreach (GameObject g in GameManager.GetSelectedDevices())
            {
                Instantiate(g);
            }
        }
    }
}
