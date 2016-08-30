using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

//TODO: take care of game logic and money being made (get thumbs up from cable entrance.cs
public class MontageManager : MonoBehaviour
{
    [Header("Timer")]
    public Text timer;
    [Tooltip("in seconds")]
    private float _timeInterval;

    [Header("Pop-Ups")]
    public GameObject popUpBackground;
    public CanvasGroup endGamePopUp;

    private float _moneyMade = 0;

    void Start()
    {
        _timeInterval = GameManager.TimerState;
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (_timeInterval >= 0)
        {
            _timeInterval -= Time.deltaTime;
            timer.text = Mathf.Floor(_timeInterval / 60).ToString("00") + (_timeInterval % 60).ToString(":00");
            yield return null;
        }

        ShowEndGame();
    }

    private void ShowEndGame()
    {
        if (popUpBackground != null)
        {
            StopAllCoroutines();
            popUpBackground.SetActive(true);

            endGamePopUp.alpha = 1;
            endGamePopUp.interactable = true;
            endGamePopUp.blocksRaycasts = true;

            _moneyMade = GameManager.numberOfConections * 10;

            endGamePopUp.transform.GetChild(1).GetComponent<Text>().text = "You made like " + _moneyMade + "$";

            timer.enabled = false;


            GameManager.SetMoney(_moneyMade);
            GameManager.ResetSelectedItens();

            GameManager.numberOfConections = 0;
        }
    }

    public void GoToMarket()
    {
        SceneManager.LoadScene("market");
    }

    public void GoToStoreFront()
    {
        StopAllCoroutines();
        GameManager.TimerState = _timeInterval;

        SceneManager.LoadScene("store-front");
    }

    public void GoToDevicePickUp()
    {
        StopAllCoroutines();
        GameManager.TimerState = _timeInterval;
        SceneManager.LoadScene("store-back-devices");
    }

    public void GoToAssembly()
    {
        StopAllCoroutines();
        GameManager.TimerState = _timeInterval;
        SceneManager.LoadScene("store-back-building");
    }
}
