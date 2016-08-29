using UnityEngine;
using System.Collections;

public class CableSpawn : MonoBehaviour {
    
	void Awake () {

        if(GameManager.GetSelectedItems() != null)
        {
            foreach (GameObject g in GameManager.GetSelectedItems())
            {
                Instantiate(g);
            }
        }

	}
	
}
