using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class Mail : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Title = null;
    [SerializeField]
    TextMeshProUGUI emailContent = null;
    [SerializeField]
    TextMeshProUGUI NickName = null;
    [SerializeField]
    private TextMeshProUGUI VsuccessText = null;
    [SerializeField]
    private TextMeshProUGUI GsuccessText = null;
    [SerializeField]
    private TextMeshProUGUI HsuccessText = null;

    [SerializeField]
    private GameObject GmailContent = null;
    
    public void ExitButton()
    {
        GmailContent.transform.position = Vector2.down * 100;

    }
    bool Voice = false;
    bool Humor = false;
    bool Game = false;
    private void Awake()
    {
        Voice = false;
        Humor = false;
        Game = false;
    }
    
    static int  ContentNumber ;
    private Email email = null;
    private Ability ability = null;
    public MailContent mailContent = null;

    
    public void SetValue(Email email) //와 이해가 안되!
    {
        this.email = email;
        UpdateUI();
    }

    public void SetAbilityValue(Ability ability)
    {
        this.ability = ability;

    }
    
    public void ClickButonContent()
    {

        GmailContent.transform.position = Vector2.zero;
        

        if (email.NickName == "팝캣" ) //Humor 1
        {
            ContentNumber = 0;

            Debug.Log(ContentNumber);
            mailContent.UpdateUI(email);
        }
        if (email.NickName == "경기게임회사") //Voice 0
        {
            ContentNumber = 1;
 
            Debug.Log(ContentNumber);
            mailContent.UpdateUI(email);
        }
        if (email.NickName == "트키치운영자") //Game 3
        {
            ContentNumber = 2;

            Debug.Log(ContentNumber);
            mailContent.UpdateUI(email);
        }

    }

    

    public void OnClickPurchase()
    {

        RectTransform rectTransform = GetComponent<RectTransform>();
   

        
        
        if (ContentNumber == 1 && !Voice) //경기게임회사
        {
            Voice = true;

            

                Debug.Log(ContentNumber);
            VsuccessText.rectTransform.anchoredPosition = Vector2.zero;

                GameManager.Instance.CurrentUser.energy += 30000;

            VsuccessText.DOFade(0f, 3f).OnComplete(() => Despawn());


        }
        if (ContentNumber == 0 && !Humor) //캣팝
        {
            Humor = true;
            Debug.Log(ContentNumber);
            HsuccessText.rectTransform.anchoredPosition = new Vector2(0, 196);
            GameManager.Instance.CurrentUser.humans += 1000;
            HsuccessText.DOFade(0f, 3f).OnComplete(() => Despawn1());
            


        }
        if (ContentNumber == 2 && !Game ) //트키치운영자
        {
            Game = true;
        
            Debug.Log(ContentNumber);
            GsuccessText.rectTransform.anchoredPosition = new Vector2(0, 196);
            GameManager.Instance.CurrentUser.Gamepercentage += 15;
            GsuccessText.DOFade(0f, 3f).OnComplete(() => Despawn2());
            




        }

    }

    
    void Despawn() //이거공부좀 하자
    {
        VsuccessText.DOFade(1f, 0.5f);
        VsuccessText.gameObject.SetActive(false);

    }

    void Despawn1()
    {
        HsuccessText.DOFade(1f, 0.5f);
        HsuccessText.gameObject.SetActive(false);
    }

   
    void Despawn2()
    {
        GsuccessText.DOFade(1f, 0.5f);
        GsuccessText.gameObject.SetActive(false);
    }
    public void UpdateUI()
    {
        Title.text = email.Title;
        emailContent.text = email.eMailContent;
        NickName.text = email.NickName;
        
    }


}
