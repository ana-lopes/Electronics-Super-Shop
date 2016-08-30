using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public GameObject storeItemPrefab;
    public Transform storeContainer;

    void Awake()
    {
        foreach (GameObject g in GameManager.GetAllCablesGameObjects())
        {
            GameObject obj = (GameObject)Instantiate(storeItemPrefab);
            ShopItem shopItem = obj.GetComponent<ShopItem>();

            obj.transform.SetParent(storeContainer);
            shopItem.SetCable(g.GetComponentInChildren<CableComponent>(true));
        }

        //foreach (GameObject g in GameManager.GetAllDevicesGameObjects())
        //{
        //    GameObject obj = (GameObject)Instantiate(storeItemPrefab);
        //    ShopItem shopItem = obj.GetComponent<ShopItem>();

        //    obj.transform.SetParent(storeContainer);
        //    shopItem.SetComponent(g.GetComponentInChildren<DeviceComponent>(true));
        //}
    }
}
