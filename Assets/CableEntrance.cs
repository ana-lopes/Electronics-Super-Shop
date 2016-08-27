using UnityEngine;
using System.Collections;

public class CableEntrance : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject colliderObj = col.gameObject;

        if(colliderObj.tag == "cable")
        {
        }
    }
}
