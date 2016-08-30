using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public GameObject storeItemPrefab;
    public Transform storeContainer;

    void Awake()
    {
        List<GameObject> cables = GameManager.GetAllCablesGameObjects();
        List<GameObject> devices = GameManager.GetAllDeviceGameObjects();

        foreach (GameObject g in cables)
        {
            GameObject obj = (GameObject)Instantiate(storeItemPrefab);
            ShopItem shopItem = obj.GetComponent<ShopItem>();

            obj.transform.SetParent(storeContainer);
            shopItem.SetCable(g.GetComponentInChildren<CableComponent>(true));
        }

        foreach (GameObject g in devices)
        {
            GameObject obj = (GameObject)Instantiate(storeItemPrefab);
            ShopItem shopItem = obj.GetComponent<ShopItem>();

            obj.transform.SetParent(storeContainer);
            shopItem.SetDevice(g.GetComponentInChildren<DeviceComponent>(true));
        }
    }
}
