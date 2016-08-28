using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text moneyText;
    public float money;

	void Start () {

        //money = PlayerPrefs.GetFloat("money");

        moneyText.text = money.ToString();
	}
	
	void Update () {
	
	}

    public void UpdateMoney(float price)
    {
        money -= price;
        moneyText.text = money.ToString();
    }

    public void GoBack()
    {
        PlayerPrefs.SetFloat("money", money);
    }
}
