using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeEquipment : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI equipmentName = null;
    [SerializeField]
    private TextMeshProUGUI priceTextMeshProUGUI = null;
    [SerializeField]
    private Image equipmentImage = null;
    [SerializeField]
    private Image StatusequipmentImage = null;
    [SerializeField]
    private Button purchaseButton = null;
    [SerializeField]
    private Sprite[] equipmentSprite;
    [SerializeField]
    private TextMeshProUGUI equipmentExplain = null;
    private bool buyNow;

    ColorBlock cb;
    Color newColor;

    private Equipment equipment = null;
    private void Update()
    {
        if (GameManager.Instance.CurrentUser.energy < equipment.price)
        {
            cb = purchaseButton.colors;
            newColor = Color.gray;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            purchaseButton.colors = cb;
        }
        else
        {
            cb = purchaseButton.colors;
            newColor = Color.white;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            purchaseButton.colors = cb;
        }

    }
           


    public void SetValue(Equipment equipment)
    {
        this.equipment = equipment;
        UpdateUI();
    }

    public void UpdateUI()
    {
        equipmentName.text = equipment.equipmentName;
        priceTextMeshProUGUI.text = string.Format("{0} ¸Ó´Ï", equipment.price);
        equipmentImage.sprite = equipmentSprite[equipment.equipmentNumber];
        equipmentExplain.text = equipment.equipmentExplain;

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

        StatusequipmentImage.sprite = equipmentSprite[equipment.equipmentNumber];



        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();
    }


}
