using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text moneyText = null; //에너지
    [SerializeField]
    private Text humansText = null;
    [SerializeField]
    private GameObject upgradePanelTemplate = null;
    [SerializeField]
    private GameObject upgradeEquipmentPanelTemplate = null;
    [SerializeField]
    private TwichUser chatingPanelTemplate = null;
    [SerializeField]
    private MoneyText moneyTextTemplate = null;
    [SerializeField]
    private Transform pool = null;
    [SerializeField]
    private Transform poolChating;
    [SerializeField]
    private TwichUser twichUser = null;
    [SerializeField]
    private GameObject option = null;

    private Ability ability;
    enum Panels {SkillShop, EquipMent};

    Panels panels = Panels.SkillShop;
    private List<UpgradePanel> upgradePanels = new List<UpgradePanel>();
    private List<UpgradeEquipment> upgradeEquipment = new List<UpgradeEquipment>();
    private void Start()
    {
        
        UpdateEnergyPanel();
        CreatePanels();
        CreateEqupimentPanels();
        StartCoroutine(chatingInstance());
    }

    private void CreatePanels()
    {
        if (panels == Panels.SkillShop)
        {
            GameObject newPanel = null;
            UpgradePanel newPanelComponent = null;
            foreach (Ability ability in GameManager.Instance.CurrentUser.soldierList)
            {
                newPanel = Instantiate(upgradePanelTemplate, upgradePanelTemplate.transform.parent);
                newPanelComponent = newPanel.GetComponent<UpgradePanel>();
                newPanelComponent.SetValue(ability);
                newPanel.SetActive(true);
                Debug.Log("sdsadsadsadsadsa");

                upgradePanels.Add(newPanelComponent);
            }
        }
    }

    private void CreateEqupimentPanels()
    {
        GameObject newPanel = null;
        UpgradeEquipment newPanelComponent = null;
        foreach(Equipment equipment in GameManager.Instance.CurrentUser.equipmentList)
        {
            newPanel = Instantiate(upgradeEquipmentPanelTemplate, upgradeEquipmentPanelTemplate.transform.parent);
            newPanelComponent = newPanel.GetComponent<UpgradeEquipment>();
            newPanelComponent.SetValue(equipment);
            newPanel.SetActive(true);
            Debug.Log("sdsadsadsadsadsa");
            upgradeEquipment.Add(newPanelComponent);
        }
    }
    private IEnumerator chatingInstance()
    {
        GameObject newChating;
        while (true)
        { 

            if(poolChating.childCount > 0)
            {
               twichUser = poolChating.GetChild(0).GetComponent<TwichUser>();
                twichUser.RandomColor();
                twichUser.UpdateChating();
                twichUser.Show();
            }
            else
            {
                twichUser = Instantiate(chatingPanelTemplate, chatingPanelTemplate.transform.parent);
                twichUser.RandomColor();
                twichUser.UpdateChating();
                twichUser.Show();
            }

            yield return new WaitForSeconds(1f); //반복이 안되는 문제고치기기ㅣ기긱
            Debug.Log("실행됨?");
        }
    }

    public void OnClickBeaker()
    {

        GameManager.Instance.CurrentUser.energy += GameManager.Instance.CurrentUser.ePc;
        UpdateEnergyPanel();
        
        MoneyText newText = null; //생성된 오브젝트는 복사기 때문에

        if (pool.childCount > 0) //풀에 자식이 있다면 즉  //가죠오기
        {
            newText = pool.GetChild(0).GetComponent<MoneyText>(); //접근
            //getchild는 트랜스폼만 가져오기에 스크립트도 컴포넌트로 가져간다.
        }
        else //복사하기
        {
            newText = Instantiate(moneyTextTemplate, moneyTextTemplate.transform.parent);
        }
        foreach(Ability ability in GameManager.Instance.CurrentUser.soldierList)
        {
            GameManager.Instance.CurrentUser.humans += ability.amount ;
        }
        
        newText.Show(Input.mousePosition);


    }
    public void UpdateEnergyPanel()
    {
        switch(GameManager.Instance.CurrentUser.energy/ 1000)
        {
            case 10:
                Debug.Log("ddddddddddd");
                moneyText.text = string.Format("{0} 만 {1} 천원", GameManager.Instance.CurrentUser.energy/ 10000, GameManager.Instance.CurrentUser.energy/10); //1만 2천
                break;
            case 100000:
                moneyText.text = string.Format("{0} 억 {1} 만원", GameManager.Instance.CurrentUser.energy / 100000000, GameManager.Instance.CurrentUser.energy / 1000); // 1억 2032원
                break;
            default:
                moneyText.text = string.Format("{0} 원", GameManager.Instance.CurrentUser.energy);
                break;
        }
            
      
    }
    public void UpdateHumansPanel()
    {

        humansText.text = string.Format("{0}", GameManager.Instance.CurrentUser.humans);
        
    }

    public void Option()
    {
        option.transform.position = Vector2.zero;
    }

    public void exit()
    {
        option.transform.position = Vector2.down * 1000;
    }
}
