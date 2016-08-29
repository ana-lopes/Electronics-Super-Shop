using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopUIManager : MonoBehaviour {

    public Text moneyText;
    public float money;

	void Start () {
        moneyText.text = GameManager.GetTotalMoney().ToString();
        money = GameManager.GetTotalMoney();
	}

    public void UpdateMoney(float price)
    {
        money -= price;
        moneyText.text = money.ToString();

        GameManager.SetMoney(money);
    }

    public void GoBack()
    {
        SceneManager.LoadScene("store-front");
        GameManager.GetAllCables();
    }
}
