using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {
    
    void Start()
    {
        StartCoroutine(FadeAndLoad());
    }

    private IEnumerator FadeAndLoad()
    {
        float timer = 2f;

        while(timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(1);
    }
	
}
