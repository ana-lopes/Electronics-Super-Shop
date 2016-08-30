using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//THIS WHOLE THING IS A MESS
public class ShopItem : MonoBehaviour
{
    [Header("Children")]
    public Text nameObject;
    public Image imageObject;
    public Image firstEntrance;
    public Image secondEntrance;
    public Text priceObject;
    public Button buyButton;

    public GameObject itemPrefab;
    private CableComponent cableComponent;
    private DeviceComponent deviceComponent;

    private ShopUIManager _uiManager;

    private bool _isCable;

    void Awake()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<ShopUIManager>();
    }

    public void SetCable(CableComponent itemComponent)
    {
        _isCable = true;
        cableComponent = itemComponent;

        nameObject.text = cableComponent.cableName;
        priceObject.text = cableComponent.price.ToString() + " $";

        imageObject.sprite = cableComponent.image;
        firstEntrance.sprite = cableComponent.firstEntrance;

        if (cableComponent.secondEntrance != null)
        {
            secondEntrance.sprite = cableComponent.secondEntrance;
        }
        else
        {
            secondEntrance.gameObject.SetActive(false);
        }

        if (cableComponent.IsAvailabe)
        {
            buyButton.interactable = false;
        }
    }

    public void SetDevice(DeviceComponent itemComponent)
    {
        _isCable = false;

        deviceComponent = itemComponent;

        nameObject.text = deviceComponent.deviceName;
        priceObject.text = deviceComponent.price.ToString() + " $";

        imageObject.sprite = deviceComponent.image;
        firstEntrance.sprite = deviceComponent.firstEntrance;

        if (deviceComponent.secondEntrance != null)
        {
            secondEntrance.sprite = deviceComponent.secondEntrance;
        }
        else
        {
            secondEntrance.gameObject.SetActive(false);
        }

        if (deviceComponent.IsAvailabe)
        {
            buyButton.interactable = false;
        }
    }

    public void OnBuy()
    {
        if (_isCable)
        {
            if (_uiManager.money >= cableComponent.price)
            {
                if (cableComponent != null)
                {
                    cableComponent.IsAvailabe = true;
                }

                buyButton.interactable = false;
                _uiManager.UpdateMoney(cableComponent.price);

                GameManager.UpdateCableAvailability(DeviceComponentHelper.ComponentName(cableComponent.componentType), true);
            }
        }

        else
        {
            if (_uiManager.money >= deviceComponent.price)
            {
                if (deviceComponent != null)
                {
                    deviceComponent.IsAvailabe = true;
                }

                buyButton.interactable = false;
                _uiManager.UpdateMoney(deviceComponent.price);

                GameManager.UpdateCableAvailability(DeviceComponentHelper.DeviceName(deviceComponent.deviceType), true);
            }
        }
    }
}
