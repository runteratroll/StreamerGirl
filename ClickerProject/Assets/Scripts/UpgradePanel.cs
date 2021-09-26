using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{

    [SerializeField]
    private Text soldierNameText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text amountText = null;
    [SerializeField]
    private Text abilityName = null;
    [SerializeField]
    private Button purchaseButton = null; //금액이 안맞을때 작동안될려고
    [SerializeField]
    private Image soldierImage = null;
    [SerializeField]
    private Sprite[] soldierSprite;


    private Ability ability = null;
    public void SetValue(Ability ability) //솔져는 컴포넌트가 아닌 클래스 컴포넌트는 MonoBehavior를 상속받아야만 그거다.
    {

        this.ability = ability; //이거
        UpdateUI();

    }

    public void UpdateUI()
    {
        soldierNameText.text = ability.abilityName;
        priceText.text = string.Format("{0} G", ability.price);
        amountText.text = string.Format("{0}", ability.amount); //개수
        abilityName.text = ability.abilityName;
        soldierImage.sprite = soldierSprite[ability.abilityNumber];
    }

    public void OnClickPurchase()
    {

        if (GameManager.Instance.CurrentUser.energy < ability.price)  //현재에너지
        {
            return;
        }

        GameManager.Instance.CurrentUser.energy -= ability.price;
        ability.price = (long)(ability.price * 1.5f);
        ability.amount++;
        
        GameManager.Instance.CurrentUser.ePc += ability.amount * 2; //여기서 문제 다른걸 어마운트 한다면?
        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();
    }
}
