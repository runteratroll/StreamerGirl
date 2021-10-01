using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Donation : MonoBehaviour
{
    string[] twichName = new string[] { "�̽���", "��Ҹ����ƿ�", "sdkewi801", "���","�Ҿƹ���","�ڹ������ø�2��", "Ŭ���÷ξ���","�����", "�����","�ż��� ����","���콺���е�", "�̼�",
    "�����ܼ�ȣ��", "��õ����", "�뺧�Ǿ�", "TS��Ǫ", "���̸���", "����", "������", "Ʋ��10����", "�Ҿƹ�����", "���ֿ뵷������", "���", "��ǻ�ͽý����Ϲ�", "����",
    "�̰�õ��", "�ζǹ�ȣ313123133", "Nox���÷��̾�", "����","O��ConoCO", "3���"};
    string[] Contentv = new string[] { "��Ҹ���� �Ŀ��մϴ� �����ε� ��۹�â�ϼ���~", "��Ҹ��ѹ��� ���ּ���", "���׹޾ƶ�!", "��߸�����","�̰Ź�������",
    "Ŭ��Ŀ�ʹ�����׾��̱׳ɹ����̷��ִٰ�", "������", "�̰ų�������", "�����ε� ������ ���ڤѾ�!", "��������������������������������������������������, " , "hi my name is Lee, do you know Psy?"};
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
        
        //���� ���� �ټ� �ֳ�?
        randomUser = Random.Range(0, twichName.Length);
        randomContent = Random.Range(0, Contentv.Length);
        randomDonationMoney = Random.Range(0, donationMoney.Length);
        NickName.color = new Color(56f / 255f, 255f / 255f, 0f / 255f);
        NickName.text = (twichName[randomUser]);
        mid.text = "����";
        money.color = new Color(56f / 255f, 255f / 255f, 0f / 255f);
        money.text = string.Format("{0}", donationMoney[randomDonationMoney]);
        GameManager.Instance.CurrentUser.energy += donationMoney[randomDonationMoney];
        end.text = "�� �Ŀ�";
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
