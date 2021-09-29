using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyTextMeshProUGUI = null; //에너지
    [SerializeField]
    private TextMeshProUGUI humansTextMeshProUGUI = null;
    [SerializeField]
    private GameObject upgradePanelTemplate = null;
    [SerializeField]
    private GameObject upgradeEquipmentPanelTemplate = null;
    [SerializeField]
    private GameObject EmailTemplate = null;
    [SerializeField]
    private TwichUser chatingPanelTemplate = null;
    [SerializeField]
    private MoneyText moneyTextMesh = null;
    [SerializeField]
    private windowsClcik windowsClcik = null;
    [SerializeField]
    private Donation donation = null;
    [SerializeField]
    private Transform pool = null;
    [SerializeField]
    private Transform poolChating;
    [SerializeField]
    private Transform poolDonation;
    [SerializeField]
    private Transform poolClick;
    [SerializeField]
    private TwichUser twichUser = null;
    [SerializeField]
    private Mail mail = null;
    [SerializeField]
    private GameObject option = null;
    [SerializeField]
    private GameObject StatusMemo = null;
    [SerializeField]
    TextMeshProUGUI SuccessText = null;
    [SerializeField]
    private TextMeshProUGUI Money = null;
    [SerializeField]
    private TextMeshProUGUI Humans = null;
    [SerializeField]
    private Image image = null;
    [SerializeField]
    private GameObject GmailContent = null;
    [SerializeField]
    private TextMeshProUGUI CsuccessText = null;
    float spawnsTime;
    public float defaultTime = 0.05f;
    private Ability ability;
    enum Panels {SkillShop, EquipMent};

    Animator animator = null;
    Panels panels = Panels.SkillShop;
    private List<UpgradePanel> upgradePanels = new List<UpgradePanel>();
    private List<UpgradeEquipment> upgradeEquipment = new List<UpgradeEquipment>();
    private List<Mail> upgradeMail = new List<Mail>();
    GameObject newPanel = null;
    Mail newMail = null;
    public MailContent mailContent;

    [SerializeField]
    Button button = null;
    private void Start()
    {
        
        
        
        
        animator = FindObjectOfType<Animator>();
  
        CreatePanels();
        CreateEqupimentPanels();
        StartCoroutine(chatingInstance());
        StartCoroutine(donationInstance());
        UpdateEnergyPanel();
      
    }

    public bool EmailPurchase()
    {
        return true;
    }
    public bool EmailClick()
    {
        return true;
    }
 
    private void Update()
    {

        foreach (Email email in GameManager.Instance.CurrentUser.emailList)
        {
            CreateEmail(email);
            if (email.NickName == "트키치 운영자" && EmailClick())
            {
                ClickButonContent(email);


            }
            if (email.NickName == "팝캣" && EmailClick())
            {
                ClickButonContent(email);


            }
            if (email.NickName == "경기게임회사" && EmailClick())
            {
                ClickButonContent(email);


            }

            if (EmailPurchase())
            {
                OnClickPurchase(email);
            }
        }
            if (Input.GetMouseButton(0) && spawnsTime >= defaultTime)
        {

            spawnsTime = 0;
        }
        spawnsTime += Time.deltaTime;
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

    private void CreateEmail(Email email)
    {
        //GameObject newPanel = null;
        //Mail newMail = null;
        
        //foreach (Email email in GameManager.Instance.CurrentUser.emailList)
        //{
            
            
            newPanel = Instantiate(EmailTemplate, EmailTemplate.transform.parent);
            newMail = newPanel.GetComponent<Mail>();
            newMail.SetValue(email);
            
            newPanel.SetActive(true);  //생성되고 비활성화
            



            upgradeMail.Add(newMail);

            




        //}
    }
    public void OnClickPurchase(Email email)
    {
        
        if (email.NickName == "경기게임회사 ")
        {
            CsuccessText.transform.position = new Vector2(0, 570);
            GameManager.Instance.CurrentUser.energy += 30000;
        }
        if (email.NickName == "팝캣")
        {
            CsuccessText.transform.position = new Vector2(0, 570);
            GameManager.Instance.CurrentUser.humans += 1000;
        }
        if (email.NickName == "트키치운영자")
        {
            CsuccessText.transform.position = new Vector2(0, 570);
            GameManager.Instance.CurrentUser.Gamepercentage += 15;
        }
    }

    public void ClickButonContent(Email email) 
    {
        
        GmailContent.transform.position = Vector2.zero;


        if (email.NickName == "팝캣")
            mailContent.UpdateUI(email);
        if (email.NickName == "경기게임회사")
            mailContent.UpdateUI(email);
        if (email.NickName == "트키치 운영자")
            mailContent.UpdateUI(email);

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
                twichUser.UpdateShow();
                twichUser.Show();
            }
            else
            {
                twichUser = Instantiate(chatingPanelTemplate, chatingPanelTemplate.transform.parent);
                twichUser.RandomColor();
                twichUser.UpdateShow();
                twichUser.Show();
            }
        
            yield return new WaitForSeconds(1.5f); //반복이 안되는 문제고치기기ㅣ기긱

            Debug.Log("실행됨?");
        }
    }

    private IEnumerator donationInstance()
    {

        Donation newDonation = null;
        while (true)
        {
            yield return new WaitForSeconds(GameManager.Instance.CurrentUser.donationSpeed); // 30
            bool Random = RandomChance.GetThisChanceResult(70); //70%확률
            if(!Random)
            {
                yield return new WaitForSeconds(GameManager.Instance.CurrentUser.donationSpeed); //30
            }
            if (poolDonation.childCount > 0)
            {
                newDonation = poolDonation.GetChild(0).GetComponent<Donation>();
                

            }
            else
            {
                newDonation = Instantiate(donation, donation.transform.parent);
                
            }

            newDonation.UpdateDonation();
            newDonation.Show();

            yield return new WaitForSeconds(3f);
            newDonation.Exit();
                
        }
    }

    
    public void OnClickBeaker()
    {

        GameManager.Instance.CurrentUser.energy += GameManager.Instance.CurrentUser.ePc;
        UpdateEnergyPanel();
        animator.SetTrigger("ButtonClick");
        MoneyText newTextMeshProUGUI = null; //생성된 오브젝트는 복사기 때문에
        windowsClcik NewWindowsClcik = null;
        if (poolClick.childCount > 0) //풀에 자식이 있다면 즉  //가죠오기
        {
            NewWindowsClcik = poolClick.GetChild(0).GetComponent<windowsClcik>(); //접근
            //getchild는 트랜스폼만 가져오기에 스크립트도 컴포넌트로 가져간다.
        }
        else //복사하기
        {
            NewWindowsClcik = Instantiate(windowsClcik, windowsClcik.transform.parent);
        }

        if (pool.childCount > 0) //풀에 자식이 있다면 즉  //가죠오기
        {
            newTextMeshProUGUI = pool.GetChild(0).GetComponent<MoneyText>(); //접근
            //getchild는 트랜스폼만 가져오기에 스크립트도 컴포넌트로 가져간다.
        }
        else //복사하기
        {
            newTextMeshProUGUI = Instantiate(moneyTextMesh, moneyTextMesh.transform.parent);
        }
        foreach(Ability ability in GameManager.Instance.CurrentUser.soldierList)
        {
            GameManager.Instance.CurrentUser.humans += ability.amount ;
        }
        
        newTextMeshProUGUI.Show(Input.mousePosition);
        NewWindowsClcik.Show(Input.mousePosition);

    }

    
    public void UpdateEnergyPanel()
    {



        moneyTextMeshProUGUI.text = string.Format("{0} 원", GameManager.Instance.CurrentUser.energy);
        Money.text = string.Format("보유머니: \n" + "{0}", GameManager.Instance.CurrentUser.energy);

    }
            
    
    public void UpdateHumansPanel()
    {

        
        
        Humans.text = string.Format("시청자수: \n" + "{0}", GameManager.Instance.CurrentUser.humans);
        humansTextMeshProUGUI.text = string.Format("{0}", GameManager.Instance.CurrentUser.humans);

    }

    public void Option()
    {
        option.transform.position = Vector2.zero;
    }

    public void exit()
    {
        option.transform.position = Vector2.down * 1000;
    }

    public void Status()
    {
        StatusMemo.transform.position = Vector2.zero;
        
    }



    public void exitStatus()
    {
        StatusMemo.transform.position = Vector2.down * 1000;
    }

    
}
