using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Donation : MonoBehaviour
{
    string[] twichName = new string[] { "����", "��Ҹ����ƿ�", "���̸���", "���","�ƹ�","�Ҿƹ���","�ڹ��� ���ø�2�� �����¼���", "�߻��پ��ġŲ�ҽ��ǹ߰�����������" };
    string[] Contentv = new string[] { "���󤿶�", "��Ҹ��ѹ��� ���ּ���", "��������", "����������",  };
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
        
        //���� ���� �ټ� �ֳ�?
        randomUser = Random.Range(0, twichName.Length);
        randomContent = Random.Range(0, Contentv.Length);
        randomDonationMoney = Random.Range(0, donationMoney.Length);
        NickName.color = new Color(36f / 255f, 252f / 255f, 255f / 255f);
        NickName.text = (twichName[randomUser]);
        mid.text = "����";
        money.color = new Color(36f / 255f, 252f / 255f, 255f / 255f);
        money.text = string.Format("{0}", donationMoney[randomDonationMoney]);
        GameManager.Instance.CurrentUser.energy += donationMoney[randomDonationMoney];
        end.text = "�� �Ŀ�";
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
