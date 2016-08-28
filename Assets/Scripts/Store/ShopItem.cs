using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [Header("Children")]
    public Text nameObject;
    public Image imageObject;
    public Text descriptionObject;
    public Text priceObject;
    public Button buyButton;

    [Header("Item Info")]
    public GameObject itemPrefab;
    private Component component;

    [Header("Other")]
    public UIManager uiManager;

    void Awake()
    {

        if (itemPrefab != null)
        {
            component = itemPrefab.GetComponentInChildren<Component>();
            nameObject.text = component.ComponentName.ToUpper();
            descriptionObject.text = component.description;
            imageObject.sprite = component.image;
            priceObject.text = component.price.ToString() + " $";

            if (buyButton != null && component.IsAvailabe)
            {
                buyButton.interactable = false;
                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
            }
        }
    }

    public void OnBuy()
    {
        if (uiManager.money >= component.price)
        {
            if (component != null)
            {
                component.IsAvailabe = true;
            }

            buyButton.interactable = false;
            buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
            uiManager.UpdateMoney(component.price);
        }
    }
}
