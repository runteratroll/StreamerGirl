using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyTextMeshProUGUI = null; //������
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
    private GameObject EmailGameObj = null;
    [SerializeField]
    private TextMeshProUGUI Money = null;
    [SerializeField]
    private TextMeshProUGUI Humans = null;
    [SerializeField]
    private Image image = null;
    [SerializeField]
    private GameObject GmailContent = null;
    
    float spawnsTime;
    public float defaultTime = 0.05f;
    public Ability ability;
    enum Panels {SkillShop, EquipMent};
    bool Game = false;
    bool Voice = false;
    bool Humor = false;
    Animator animator = null;
    Panels panels = Panels.SkillShop;
    private List<UpgradePanel> upgradePanels = new List<UpgradePanel>();
    private List<UpgradeEquipment> upgradeEquipment = new List<UpgradeEquipment>();
    private List<Mail> upgradeMail = new List<Mail>();

    [SerializeField]
    private Sprite idelEmail = null;
    [SerializeField]
    private Sprite AarmEmail = null;
    [SerializeField]
    private Image Email = null;

    private void Start()
    {
        
        
        
        
        animator = FindObjectOfType<Animator>();
        Debug.Log("STAST");
        StartCoroutine(CreateEmail());
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
 
    private IEnumerator CreateEmail()
    {
        GameObject newPanel;
        Mail newMail = null;
        int i = 0;
        foreach (Email email in GameManager.Instance.CurrentUser.emailList)
        {


            newPanel = Instantiate(EmailTemplate, EmailTemplate.transform.parent);

            newMail = newPanel.GetComponent<Mail>();
            newMail.SetValue(email);


            
            yield return new WaitForSeconds(30f);
            Email.sprite = AarmEmail;
            
            newPanel.SetActive(true);
            upgradeMail.Add(newMail);
            

            //    foreach (Ability ability in GameManager.Instance.CurrentUser.soldierList)
            //    {

            //        Debug.Log("��������������������������������������");
            //        if (ability.abilityName == "��Ҹ�")
            //        {
            //            if (ability.amount >= 20)
            //            {
            //                if(email.NickName == "����ȸ��")
            //                    newPanel.SetActive(true);
            //            }
            //        }
            //        else if (ability.abilityName == "����")
            //        {
            //            if (ability.amount >= 15)
            //            {
            //                if (email.NickName == "��Ĺ")
            //                    newPanel.SetActive(true);
            //            }
            //        }
            //        else if (ability.abilityName == "�Ƿ�")
            //        {
            //            if (ability.amount >= 10)
            //            {
            //                if (email.NickName == "ƮŰġ���")
            //                    newPanel.SetActive(true);
            //            }
            //        }




            //}



        }
        
     




    }
    
    public void emailClick()
    {
        Email.sprite = idelEmail;
    }
    //private void SerchBool(GameObject newPanel)
    //{

    //    if (ability.amount > 5 && ability.abilityName == "�Ƿ�")
    //    {
    //        Game = true;
    //        newPanel.SetActive(true);
    //    }
    //    else if (ability.amount > 15 && ability.abilityName == "��Ҹ�")
    //    {
    //        Voice = true;
    //        newPanel.SetActive(true);
    //    }
    //    else if (ability.amount > 10 && ability.abilityName == "����")
    //    {
    //        Humor = true;
    //        newPanel.SetActive(true);
    //    }

    //    if (Game && Voice && Humor)
    //        return;




    //}



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
        
            yield return new WaitForSeconds(1.5f); //�ݺ��� �ȵǴ� ������ġ���ӱ��

            Debug.Log("�����?");
        }
    }

    private IEnumerator donationInstance()
    {

        Donation newDonation = null;
        while (true)
        {
            yield return new WaitForSeconds(GameManager.Instance.CurrentUser.donationSpeed); // 15
            bool Random = RandomChance.GetThisChanceResult(70); //70%Ȯ��
            if(!Random)
            {
                yield return new WaitForSeconds(GameManager.Instance.CurrentUser.donationSpeed); //15
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
            newDonation.SoundSS();
            yield return new WaitForSeconds(4f);
            newDonation.Exit();
                
        }
    }

    
    public void OnClickBeaker()
    {

        GameManager.Instance.CurrentUser.energy += GameManager.Instance.CurrentUser.ePc;
        UpdateEnergyPanel();
        animator.SetTrigger("Click");
        MoneyText newTextMeshProUGUI = null; //������ ������Ʈ�� ����� ������
        windowsClcik NewWindowsClcik = null;
        if (poolClick.childCount > 0) //Ǯ�� �ڽ��� �ִٸ� ��  //���ҿ���
        {
            NewWindowsClcik = poolClick.GetChild(0).GetComponent<windowsClcik>(); //����
            //getchild�� Ʈ�������� �������⿡ ��ũ��Ʈ�� ������Ʈ�� ��������.
        }
        else //�����ϱ�
        {
            NewWindowsClcik = Instantiate(windowsClcik, windowsClcik.transform.parent);
        }

        if (pool.childCount > 0) //Ǯ�� �ڽ��� �ִٸ� ��  //���ҿ���
        {
            newTextMeshProUGUI = pool.GetChild(0).GetComponent<MoneyText>(); //����
            //getchild�� Ʈ�������� �������⿡ ��ũ��Ʈ�� ������Ʈ�� ��������.
        }
        else //�����ϱ�
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



        moneyTextMeshProUGUI.text = string.Format("{0} ��", GameManager.Instance.CurrentUser.energy);
        Money.text = string.Format("�����Ӵ�: \n" + "{0}", GameManager.Instance.CurrentUser.energy);

    }
            
    
    public void UpdateHumansPanel()
    {

        
        
        Humans.text = string.Format("��û�ڼ�: \n" + "{0}", GameManager.Instance.CurrentUser.humans);
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

    public void EmailShow()
    {
        
            EmailGameObj.transform.position = new Vector2(-6, 0);
        
    }
    public void exitEmail()
    {
        EmailGameObj.transform.position = Vector2.down * 1000;
    }

    public void exitStatus()
    {
        StatusMemo.transform.position = Vector2.down * 1000;
    }

    
}
