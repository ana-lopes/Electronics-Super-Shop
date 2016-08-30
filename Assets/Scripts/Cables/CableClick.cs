using UnityEngine;
using System.Collections;

public class CableClick : MonoBehaviour {
   
    void OnMouseDown()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        GameManager.AddCableSelection(GetComponent<CableComponent>());
        transform.GetChild(0).gameObject.SetActive(true);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
    }
}
