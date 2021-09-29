using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Donation : MonoBehaviour
{
    string[] twichName = new string[] { "승훈", "목소리좋아요", "내이름은", "어머","아버","할아버지","박물관 템플릿2개 훔지는수연", "발뻗다양념치킨소스의발각락묻힌수연" };
    string[] Contentv = new string[] { "라라라ㅏ라", "목소리한번만 내주세요", "ㅇㅇㅇㅇ", "ㅋㅋㅋㅋㅋ",  };
    int[] donationMoney = new int[] { 1000, 1004, 2800, 5800};
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Transform poolDonation;
    [SerializeField]
    private TextMeshProUGUI NickName;
    
    [SerializeField]
    private TextMeshProUGUI Content;

    [SerializeField]
    private TextMeshProUGUI mid;

    [SerializeField]
    private TextMeshProUGUI money;
    [SerializeField]
    private TextMeshProUGUI end;


    int randomUser = 0;
    int randomContent = 0;
    int randomDonationMoney = 0;

    public void UpdateDonation()
    {
        
        //색깔 따로 줄수 있나?
        randomUser = Random.Range(0, twichName.Length);
        randomContent = Random.Range(0, Contentv.Length);
        randomDonationMoney = Random.Range(0, donationMoney.Length);
        NickName.color = new Color(36f / 255f, 252f / 255f, 255f / 255f);
        NickName.text = (twichName[randomUser]);
        mid.text = "님이";
        money.color = new Color(36f / 255f, 252f / 255f, 255f / 255f);
        money.text = string.Format("{0}", donationMoney[randomDonationMoney]);
        GameManager.Instance.CurrentUser.energy += donationMoney[randomDonationMoney];
        end.text = "원 후원";
        Content.text = (Contentv[randomContent]);


    }
    public void Show()
    {

        gameObject.transform.position = Vector2.zero;
        gameObject.transform.position = Vector2.down * 0.5f;

        transform.SetParent(canvas.transform);
        gameObject.SetActive(true);
    }

    public void Exit()
    {

        transform.SetParent(poolDonation);
        gameObject.SetActive(false);
    }

}
