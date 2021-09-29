using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradePanel : MonoBehaviour
{

    
    [SerializeField]
    private TextMeshProUGUI priceTextMeshProUGUI = null;
    [SerializeField]
    private TextMeshProUGUI amountTextMeshProUGUI = null;
    [SerializeField]
    private TextMeshProUGUI abilityName = null;
    [SerializeField]
    private Button purchaseButton = null; //�ݾ��� �ȸ����� �۵��ȵɷ���
    [SerializeField]
    private Image soldierImage = null;
    [SerializeField]
    private Sprite[] soldierSprite;
    [SerializeField]
    private TextMeshProUGUI abilityExplain = null;
    [SerializeField]
    private TextMeshProUGUI Name = null;
    [SerializeField]
    private TextMeshProUGUI Skill = null;
    [SerializeField]
    private TextMeshProUGUI Voice = null;
    [SerializeField]
    private TextMeshProUGUI humor = null;
    [SerializeField]
    private TextMeshProUGUI Game = null;
    [SerializeField]
    

    private Image image = null;


    private Ability ability = null;
    public void SetValue(Ability ability) //������ ������Ʈ�� �ƴ� Ŭ���� ������Ʈ�� MonoBehavior�� ��ӹ޾ƾ߸� �װŴ�.
    {

        this.ability = ability; //�̰�
        UpdateUI();

    }

    public void UpdateUI()
    {

        priceTextMeshProUGUI.text = string.Format("{0} G", ability.price);
        amountTextMeshProUGUI.text = string.Format("{0}", ability.amount); //����
        abilityName.text = ability.abilityName;
        abilityExplain.text = ability.abilityExplain;
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
        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();

        if (ability.abilityName == "��Ҹ�")
        {
            GameManager.Instance.CurrentUser.Voicepercentage += 2;
            Voice.text = string.Format("��Ҹ� Lv.{0} " + "��Ҹ�ä��Ȯ�� {1}%", ability.amount, GameManager.Instance.CurrentUser.Voicepercentage);
            
            Debug.Log("��Ҹ�����!!");

        }
        if (ability.abilityName == "����")
        {
            GameManager.Instance.CurrentUser.Humorpercentage += 2;
            humor.text = string.Format("���� Lv.{0}" + "����ä��Ȯ�� {1}%", ability.amount, GameManager.Instance.CurrentUser.Humorpercentage);
        }

        if (ability.abilityName == "�Ƿ�")
        {
            GameManager.Instance.CurrentUser.Gamepercentage += 2;
            Game.text = string.Format("�Ƿ� Lv.{0}" + "�Ƿ�ä��Ȯ�� {1}%", ability.amount, GameManager.Instance.CurrentUser.Gamepercentage);
        }
        if (ability.abilityName == "�����̼�" ) //�����̼� ��������Ʈ���
        {
            if (ability.amount > 10) //�����̼� �ִ� ���� +3 
            {
                return;
            }
            GameManager.Instance.CurrentUser.donationRandom += 3; //Ȯ�� 3�� ���� 10�� �ִ�
            
        }


        if (ability.abilityName == "���׼�")
        {
            if (ability.amount > 20) //���׼� �ִ� ���� 
            {
                return;
            }
            GameManager.Instance.CurrentUser.donationSpeed -= 2; //�����̼� 30�ʿ��� 2�� ���� 20�� �ִ�
        }

        

        Skill.text = string.Format("������ų\n\n" +
                   "�����̼� Ȯ�� {0}%\n" + "�����̼� �ӵ� {1}��\n",
                   GameManager.Instance.CurrentUser.donationRandom, GameManager.Instance.CurrentUser.donationSpeed);


        GameManager.Instance.CurrentUser.ePc += ability.amount * 2; //���⼭ ���� �ٸ��� ���Ʈ �Ѵٸ�?
        
    }
}
