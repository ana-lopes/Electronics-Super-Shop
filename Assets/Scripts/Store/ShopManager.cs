using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {

    [Tooltip("Must have the same length")]
    public GameObject[] itemList;
    [Tooltip("Must have the same length")]
    public bool[] availableItemList;

	void Awake () {
	
        if(itemList.Length > 0)
        {
            for(int i = 0; i < itemList.Length; i++)
            {
                itemList[i].GetComponentInChildren<Component>().IsAvailabe = availableItemList[i];
            }
        }
	}
	
	void Update () {
	
	}
}
