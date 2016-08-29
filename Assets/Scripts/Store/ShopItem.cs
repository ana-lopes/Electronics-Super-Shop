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
    private DeviceComponent component;
    
    private ShopUIManager _uiManager;

    void Awake()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<ShopUIManager>();
    }

    public void SetComponent(DeviceComponent itemComponent)
    {
        component = itemComponent;

        nameObject.text = component.ComponentName.ToUpper();
        descriptionObject.text = component.description;
        imageObject.sprite = component.image;
        priceObject.text = component.price.ToString() + " $";

        if(component.IsAvailabe)
        {
            buyButton.interactable = false;
            buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
        }
    }

    public void OnBuy()
    {
        if (_uiManager.money >= component.price)
        {
            if (component != null)
            {
                component.IsAvailabe = true;
            }

            buyButton.interactable = false;
            buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
            _uiManager.UpdateMoney(component.price);

            GameManager.UpdateComponentAvailability(component.ComponentName, true);
        }
    }
}
