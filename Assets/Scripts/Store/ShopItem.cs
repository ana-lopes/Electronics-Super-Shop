using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [Header("Children")]
    public Text nameObject;
    public Image imageObject;
    public Image firstEntrance;
    public Image secondEntrance;
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

        nameObject.text = DeviceComponentHelper.ComponentName(component.componentType).ToUpper();
        priceObject.text = component.price.ToString() + " $";

        imageObject.sprite = component.image;
        firstEntrance.sprite = component.firstEntrance;

        if (component.secondEntrance != null)
        {
            secondEntrance.sprite = component.secondEntrance;
        }
        else
        {
            secondEntrance.gameObject.SetActive(false);
        }
        

        if (component.IsAvailabe)
        {
            buyButton.interactable = false;
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
            _uiManager.UpdateMoney(component.price);

            GameManager.UpdateCableAvailability(DeviceComponentHelper.ComponentName(component.componentType), true);
        }
    }
}
