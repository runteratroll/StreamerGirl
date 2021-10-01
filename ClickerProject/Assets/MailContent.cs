using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MailContent : MonoBehaviour
{



    [SerializeField]
    TextMeshProUGUI CTitle = null;
    [SerializeField]
    TextMeshProUGUI CemailContent = null;
    [SerializeField]
    TextMeshProUGUI CNickName = null;
    



    public void UpdateUI(Email email)
    {
        CTitle.text = email.Title;
       
        CemailContent.text = email.eMailContent;
        CNickName.text = email.NickName;

    }

    
    private float defaultTime = 1f;
    private float spawnTime = 0;
    









}
