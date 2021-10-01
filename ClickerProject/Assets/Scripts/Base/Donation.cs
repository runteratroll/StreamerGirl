using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Donation : MonoBehaviour
{
    string[] twichName = new string[] { "戚渋汎", "鯉社軒疏焼推", "sdkewi801", "嬢袴","拝焼獄走","酵弘淫奴巴鹸2鯵", "適掘獣稽鐘崎榎","仙耕像", "搾因鯵","重識廃 酔政","原酔什舌鳶球", "耕社",
    "政艦嬬呪硲企", "蓄探椴椴", "葛婚杷焼", "TS爾祢", "鎧戚硯亀", "追昔", "攻妬戚", "堂艦10鰍託", "拝焼号妬戚", "謝爽遂儀晒精暗", "剛雌", "陳濃斗獣什奴析鋼", "厩嬢",
    "戚引探仙", "稽暁腰硲313123133", "Nox詔巴傾戚嬢", "傾郊","O塘ConoCO", "3崎欠"};
    string[] Contentv = new string[] { "鯉社軒笈壱 板据杯艦陥 蒋生稽亀 号勺腰但馬室推~", "鯉社軒廃腰幻 鎧爽室推", "亀革閤焼虞!", "近襟牽近近襟","戚暗閤生室推",
    "適軒朕格巷毘球革焼戚益撹攻妬戚稽赤陥亜", "斐伯伯", "戚暗蟹閤生偲", "蒋生稽亀 毘鎧壱 ぁ切ぱ焼!", "たたたたたたたたたたたたたたたたたたたたたたたたた, " , "hi my name is Lee, do you know Psy?"};
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

    AudioSource audioSource = null;

    int randomUser = 0;
    int randomContent = 0;
    int randomDonationMoney = 0;

    public void UpdateDonation()
    {
        
        //事薗 魚稽 匝呪 赤蟹?
        randomUser = Random.Range(0, twichName.Length);
        randomContent = Random.Range(0, Contentv.Length);
        randomDonationMoney = Random.Range(0, donationMoney.Length);
        NickName.color = new Color(56f / 255f, 255f / 255f, 0f / 255f);
        NickName.text = (twichName[randomUser]);
        mid.text = "還戚";
        money.color = new Color(56f / 255f, 255f / 255f, 0f / 255f);
        money.text = string.Format("{0}", donationMoney[randomDonationMoney]);
        GameManager.Instance.CurrentUser.energy += donationMoney[randomDonationMoney];
        end.text = "据 板据";
        Content.text = (Contentv[randomContent]);


    }

    public void SoundSS()
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    public void Show()
    {
        transform.SetParent(canvas.transform);
        gameObject.SetActive(true);
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(170, 45);


    }

    public void Exit()
    {

        transform.SetParent(poolDonation);
        gameObject.SetActive(false);
    }

}
