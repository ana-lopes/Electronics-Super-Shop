using UnityEngine;
using System.Collections;

public class ItemClick : MonoBehaviour {
   
    void OnMouseDown()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        GameManager.AddItemSelection(GetComponent<DeviceComponent>());
        transform.GetChild(0).gameObject.SetActive(true);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
    }
}
