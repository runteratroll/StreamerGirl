using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Mail : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Title = null;
    [SerializeField]
    TextMeshProUGUI emailContent = null;
    [SerializeField]
    TextMeshProUGUI NickName = null;

    [SerializeField]
    private GameObject GmailContent = null;
    public void ExitButton()
    {
        GmailContent.transform.position = Vector2.down * 100;

    }

    private Email email = null;

    public MailContent mailContent = null;
    public void SetValue(Email email)
    {
        this.email = email;
        UpdateUI();
    }

    
    
  


    public void UpdateUI()
    {
        Title.text = email.Title;
        emailContent.text = email.eMailContent;
        NickName.text = email.NickName;
    }

    






}
