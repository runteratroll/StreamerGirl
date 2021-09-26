using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeEquipment : MonoBehaviour
{
    [SerializeField]
    private Text equipmentName = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Image equipmentImage = null;
    [SerializeField]
    private Button purchaseButton = null;
    [SerializeField]
    private Sprite[] equipmentSprite;
    private bool buyNow;
    

    private Equipment equipment = null;



    public void SetValue(Equipment equipment)
    {
        this.equipment = equipment;
        UpdateUI();
    }

    public void UpdateUI()
    {
        equipmentName.text = equipment.equipmentName;
        priceText.text = string.Format("{0} ¸Ó´Ï", equipment.price);
        equipmentImage.sprite = equipmentSprite[equipment.equipmentNumber];

    }

    public void OnClickPurchase()
    {

        if(GameManager.Instance.CurrentUser.energy < equipment.price)
        {
            return;
        }
        if(equipment.buy)
        {
            return;
        }
        equipment.buy = true;
        GameManager.Instance.CurrentUser.energy -= equipment.price;
        GameManager.Instance.CurrentUser.ePc *= equipment.oCm;
       



        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();
    }
}
