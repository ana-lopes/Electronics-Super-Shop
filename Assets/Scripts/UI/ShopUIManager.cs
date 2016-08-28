using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopUIManager : MonoBehaviour {

    public Text moneyText;
    public float money;

	void Start () {

        GameManager.GetAllComponents();

        moneyText.text = GameManager.GetTotalMoney().ToString();
	}
	
	void Update () {
	
	}

    public void UpdateMoney(float price)
    {
        money -= price;
        moneyText.text = money.ToString();

        GameManager.SetMoney(money);
    }

    public void GoBack()
    {
        PlayerPrefs.SetFloat("money", money);
        PlayerPrefs.Save();
        //TODO: guardar info de material comprado para passar à próxima cena
        SceneManager.LoadScene("store-back");
        GameManager.GetAllComponents();
    }
}
