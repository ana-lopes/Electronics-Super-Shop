using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public GameObject storeItemPrefab;
    public Transform storeContainer;

    void Awake()
    {

        //if(itemList.Length > 0)
        //{
        //    for(int i = 0; i < itemList.Length; i++)
        //    {
        //        itemList[i].GetComponentInChildren<Component>().IsAvailabe = availableItemList[i];
        //    }
        //}

        foreach (GameObject g in GameManager.GetAllGameObjectComponents())
        {
            GameObject obj = (GameObject)Instantiate(storeItemPrefab);
            ShopItem shopItem = obj.GetComponent<ShopItem>();

            obj.transform.SetParent(storeContainer);
            shopItem.SetComponent(g.GetComponentInChildren<Component>(true));
        }
    }

    void Update()
    {

    }
}
