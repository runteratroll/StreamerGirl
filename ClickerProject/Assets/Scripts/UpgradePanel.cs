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
    private Button purchaseButton = null; //금액이 안맞을때 작동안될려고
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
    public void SetValue(Ability ability) //솔져는 컴포넌트가 아닌 클래스 컴포넌트는 MonoBehavior를 상속받아야만 그거다.
    {

        this.ability = ability; //이거
        UpdateUI();

    }

    public void UpdateUI()
    {

        priceTextMeshProUGUI.text = string.Format("{0} G", ability.price);
        amountTextMeshProUGUI.text = string.Format("{0}", ability.amount); //개수
        abilityName.text = ability.abilityName;
        abilityExplain.text = ability.abilityExplain;
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
        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();

        if (ability.abilityName == "목소리")
        {
            GameManager.Instance.CurrentUser.Voicepercentage += 2;
            Voice.text = string.Format("목소리 Lv.{0} " + "목소리채팅확률 {1}%", ability.amount, GameManager.Instance.CurrentUser.Voicepercentage);
            
            Debug.Log("목소리증가!!");

        }
        if (ability.abilityName == "유머")
        {
            GameManager.Instance.CurrentUser.Humorpercentage += 2;
            humor.text = string.Format("유머 Lv.{0}" + "유머채팅확률 {1}%", ability.amount, GameManager.Instance.CurrentUser.Humorpercentage);
        }

        if (ability.abilityName == "실력")
        {
            GameManager.Instance.CurrentUser.Gamepercentage += 2;
            Game.text = string.Format("실력 Lv.{0}" + "실력채팅확률 {1}%", ability.amount, GameManager.Instance.CurrentUser.Gamepercentage);
        }
        if (ability.abilityName == "도네이션" ) //도네이션 스프라이트라면
        {
            if (ability.amount > 10) //도네이션 최대 객수 +3 
            {
                return;
            }
            GameManager.Instance.CurrentUser.donationRandom += 3; //확률 3퍼 증가 10번 최대
            
        }


        if (ability.abilityName == "리액션")
        {
            if (ability.amount > 20) //리액션 최대 객수 
            {
                return;
            }
            GameManager.Instance.CurrentUser.donationSpeed -= 2; //도네이션 30초에서 2초 단축 20번 최대
        }

        

        Skill.text = string.Format("보유스킬\n\n" +
                   "도네이션 확률 {0}%\n" + "도네이션 속도 {1}초\n",
                   GameManager.Instance.CurrentUser.donationRandom, GameManager.Instance.CurrentUser.donationSpeed);


        GameManager.Instance.CurrentUser.ePc += ability.amount * 2; //여기서 문제 다른걸 어마운트 한다면?
        
    }
}
