using UnityEngine;
using System.Collections;

public class DeviceClick : MonoBehaviour {

    void OnMouseDown()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        //GameManager.AddCableSelection(GetComponent<DeviceComponent>());
        transform.GetChild(0).gameObject.SetActive(true);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
    }
}
