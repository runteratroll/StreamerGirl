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
    private Button purchaseButton = null; //�ݾ��� �ȸ����� �۵��ȵɷ���
    [SerializeField]
    private Image soldierImage = null;
    [SerializeField]
    private Sprite[] soldierSprite;


    private Ability ability = null;
    public void SetValue(Ability ability) //������ ������Ʈ�� �ƴ� Ŭ���� ������Ʈ�� MonoBehavior�� ��ӹ޾ƾ߸� �װŴ�.
    {

        this.ability = ability; //�̰�
        UpdateUI();

    }

    public void UpdateUI()
    {
        soldierNameText.text = ability.abilityName;
        priceText.text = string.Format("{0} G", ability.price);
        amountText.text = string.Format("{0}", ability.amount); //����
        abilityName.text = ability.abilityName;
        soldierImage.sprite = soldierSprite[ability.abilityNumber];
    }

    public void OnClickPurchase()
    {

        if (GameManager.Instance.CurrentUser.energy < ability.price)  //���翡����
        {
            return;
        }

        GameManager.Instance.CurrentUser.energy -= ability.price;
        ability.price = (long)(ability.price * 1.5f);
        ability.amount++;
        
        GameManager.Instance.CurrentUser.ePc += ability.amount * 2; //���⼭ ���� �ٸ��� ���Ʈ �Ѵٸ�?
        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();
    }
}
