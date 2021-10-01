using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Donation : MonoBehaviour
{
    string[] twichName = new string[] { "이승훈", "목소리좋아요", "sdkewi801", "어머","할아버지","박물관템플릿2개", "클래시로얄브금","재미짐", "비공개","신선한 우유","마우스장패드", "미소",
    "유니콘수호대", "추천팡팡", "노벨피아", "TS샴푸", "내이름도", "케인", "뭉탱이", "틀니10년차", "할아방탱이", "손주용돈뺏은거", "밥상", "컴퓨터시스템일반", "국어",
    "이과천재", "로또번호313123133", "Nox앱플레이어", "레바","O토ConoCO", "3브루"};
    string[] Contentv = new string[] { "목소리듣고 후원합니다 앞으로도 방송번창하세요~", "목소리한번만 내주세요", "도네받아라!", "뜬뜨르뜬뜬뜨","이거받으세요",
    "클리커너무힘드네아이그냥뭉탱이로있다가", "흐헤헤", "이거나받으셔", "앞으로도 힘내고 ㄱ자ㅡ아!", "ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏ, " , "hi my name is Lee, do you know Psy?"};
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
        
        //색깔 따로 줄수 있나?
        randomUser = Random.Range(0, twichName.Length);
        randomContent = Random.Range(0, Contentv.Length);
        randomDonationMoney = Random.Range(0, donationMoney.Length);
        NickName.color = new Color(56f / 255f, 255f / 255f, 0f / 255f);
        NickName.text = (twichName[randomUser]);
        mid.text = "님이";
        money.color = new Color(56f / 255f, 255f / 255f, 0f / 255f);
        money.text = string.Format("{0}", donationMoney[randomDonationMoney]);
        GameManager.Instance.CurrentUser.energy += donationMoney[randomDonationMoney];
        end.text = "원 후원";
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
