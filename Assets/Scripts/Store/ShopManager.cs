using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public GameObject storeItemPrefab;
    public Transform storeContainer;

    void Awake()
    {
        foreach (GameObject g in GameManager.GetAllGameObjectComponents())
        {
            GameObject obj = (GameObject)Instantiate(storeItemPrefab);
            ShopItem shopItem = obj.GetComponent<ShopItem>();

            obj.transform.SetParent(storeContainer);
            shopItem.SetComponent(g.GetComponentInChildren<DeviceComponent>(true));
        }
    }
}
