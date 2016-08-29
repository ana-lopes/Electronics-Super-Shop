using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrontStoreUIManager : MonoBehaviour {

    public GameObject briefingUI;
    public Image firstDevice;
    public Image secondDevice;
    public Image entrance;
    public Text price;
    public Text totalTime;
    
    private Image _popUpBackground;
    private Briefing _briefing;

	void Start () {

        _briefing = GameManager.GetRandomBriefing();

        _popUpBackground = GameObject.Find("PopUpBackground").GetComponent<Image>();

        GameManager.GetSetBriefing = _briefing;
        SetBriefingUI();
	}

    private void SetBriefingUI()
    {
        firstDevice.sprite = _briefing.firstDevice;
        secondDevice.sprite = _briefing.secondDevice;
        entrance.sprite = _briefing.entrance;
        price.text = _briefing.price.ToString();
        totalTime.text = Mathf.Floor(_briefing.totalTime / 60).ToString("00") + (_briefing.totalTime % 60).ToString(":00");
    }
	
    public void GotItBtn()
    {
        GameManager.TimerState = _briefing.totalTime;

        StartCoroutine(WaitForAnimation(briefingUI.GetComponent<CanvasGroup>()));
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
