using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour {

    private CanvasGroup _briefing;
    private Image _popUpBackground;

	void Start () {

        //TODO: get random briefing
        _briefing = GameObject.Find("Briefing").GetComponent<CanvasGroup>();
        _popUpBackground = GameObject.Find("PopUpBackground").GetComponent<Image>();
	}
	
    public void GotItBtn()
    {
        //TODO: get timer from briefing
        GameManager.TimerState = 60;
        StartCoroutine(WaitForAnimation(_briefing));
        StartCoroutine(Fade(_popUpBackground));
    }

    private IEnumerator WaitForAnimation(CanvasGroup cg)
    {
        Animation anim = cg.gameObject.GetComponent<Animation>();

        anim.Play();
        cg.interactable = false;
        cg.blocksRaycasts = false;

        while (anim.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene("store-back-cables");
        DestroyObject(cg.gameObject);
    }

    private IEnumerator Fade(Image background)
    {
        while(background.color.a > 0)
        {
            background.color = new Color(background.color.r, background.color.g, background.color.b, background.color.a - Time.deltaTime*0.5f);
            yield return null;
        }
    }
}
