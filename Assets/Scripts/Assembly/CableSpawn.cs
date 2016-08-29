using UnityEngine;
using System.Collections;

public class CableSpawn : MonoBehaviour {
    
	void Awake () {

        if(GameManager.GetSelectedCables() != null)
        {
            foreach (GameObject g in GameManager.GetSelectedCables())
            {
                Instantiate(g);
            }
        }

	}
	
}
