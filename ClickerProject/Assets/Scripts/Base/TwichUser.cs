using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class TwichUser : MonoBehaviour
{



    public int abilityNumber;



    List<string> twichName = new List<string>() {"�������ؿ�", "����","�ü��԰�ʹ�", "���", "������","�������ҸӴ�",
        "�߽�����Ÿ����", "�縻�ǹ���", "adfwewersdfsd",  "Ʈ��10����", "�ϲ�������", "�Ҿƹ���", "Ʋ", "�ڹ������ø�2����ģ����","���ð��̺���Ż��","�ڰ������ѳ�",
    "sfskfskfskf", "�����", "�������������", "����", "ask��", "��Ծ��", "500����Ʈ", "����������?", "�ڵ�����", "�ҽ�Ʈ��","�����Ӹ��̽��Ͱ�","����","�ۿ��� 10�ʱ�ٸ����",
    "�����������","������","��������","����","ctrlAwls","NameSak","Assaion","���԰�ʹ�","��������̾���","�Ȱ满�Ƿη�", "����Ƽ���ϰ�;�Ф�","�ѹ����̾��ּ���","�����ϰ�",
    "���Ӹ��̽��Ͱ�������","��¦","��ǥ�ϰ���� ���","������������","�������̽���","�����","3��Ÿ��","����������>","�𸮾�ΰ���Ž","�ȳ�","���Ϳ���","���伥����","2312912321",
    "���ܽ� ����", "��ķ������","�����","�����ø�","������ ������","��ȹ����5��","�Ը�����ʹ�.","������","akjsdfhsdklfsdf","�ܺ���","���","Ʈ���忩��","��_��Ĺ","�󰡺Ҹ�",
     "���۵��۵���","��ȣ����ǿ���","������","����̻�Ʋ��","���̻��ξ�����","����","ponyTail", "Rainbows", "1231dsfs", "0505sim" , "revolution","����1���� ����Ʈ",
    "PepciCoCa", "MintChoko482482", "121", "KimChiman"}; //1

    List<string> Chatingv = new List<string>() { "���� �����ϳ���?", "�ü�������", "������������", "00�� �չ�?",
        "���赵�赵�赵�赵�赵�赵�赵�赵�赵�赵��", "��ó���� �޽����Դϴ�","�� �����ϸ� �ȵ�?","��󤿤�", "����", "����","����","?","?","?","���ڰǸ���;;", "��������ڴ�",
    "���õ� �װ����Ͻ�?","�ƴ�","��","�ɽ��ϴ�","����","������������������","�װǸ���","��������","���Թ�","�󸮶󸮷�", "��Ģ���� �̰ž?","���̰� ���̰�!", "���׼Ǵ޴�~",
        "�����̶�� ����ε� Ű������ �߸��ߵ�", "���ֱ׳� �����̷� �ִٰ� �����Խ� ���̱׳�", "�������� ��û���չ��ؿ�", "��Ծ��","������", "��Ʃ������������̵� �ȳɾȳ�~",
     "�ȷο��س�����~", "��Ʃ��� �Խ��ϴ�~", "�� ��̰ڴ�","�ֱ��ѹ���...", "����","���ù��ϼ̳���?", "�乹����?", "�ϻ��̾߱��� Ǯ�����", "��Ʈ��","12�ö� �����ڳ׿�Ф�", "�ִʾ��� �ִʾ���",
    "���� ���̽�~"};
    List<string> viewers = new List<string>() { "���� ������~ ���� �����~", "��Ģ ��������?", "�Ŀ���ũ�� ����!!!", "�Ŵ�����û�̿�~" ,"�� �װ� �׷��� �ϴ°� �ƴѵ�",
    "�չ����?", "ǲǲ�ϱ���~","ũ�� ���� ���ذ���...","�����Թ�","ä��â�� �� �����׿�","�Ѿ����","�������� ��������","���� �̷��� �Ƴ�","�����","���õ� �װ��ϳ���?", 
    "�׷��� �̺� ������? ", "�� ������� ���̳�", "�����س��߰ڴ� ", "�������� ��������ϳ���?", "��۽��۽ð��� ���ɵ�?", "�������� �̰����Ұ���?", "��ۼ����ϴ� �� �˷��帳�ϴ� �Ӹ� �ּ���"
    ,"ó���ΰ� ������ ������� ���Ͻó� �������� ũ�ǵ�", "�ȷο��ȷο�", "�� ä���� ���ּ���"};
    List<string> voice = new List<string>() { "��Ҹ�����? ��Ҹ� ����?", "ļ ��Ҹ� �޴��ϰ�","ASMR��","��Ҹ�������Ʈ����","�ְ��ڱ� ��Ҹ�������?","�����Ͻǻ���?",
    "����������ϳ���Ф�","��Ҹ��� ��ġ ����� �����Ű�׿�", "��� Ʈ���̴׹���?"," �ȳ��ϼ��� �ִ�ȸ�� �������Դϴ�. �ٸ��� �ƴ϶� ���켷�ܸ� ���� ã�ƿԽ��ϴ� �̸���Ȯ�ΰ����ұ��?"
    ,"������ ������ Ʋ����������", "��´� ��~","��ȭå �о��ּ���! ��ȭå �о��ּ���!", "��Ҹ���� �����߽��ϴ�", "�� ��Ҹ�¾��", "�뷡�ؿ� �뷡�ؿ�","�����뷡������ε� �ߴ°� �?", 
    "����������� �����������", "�Ͱ� ��׿�"};
    List<string> humor = new List<string>() { "zzzzzzzzz", "�� �������", "����ĳ���Ͻ�","��ũ!��ũ!","����Ʈä���սôڤ�","��𼭰��׸��غ���?","�� �̺� �����Ҹ�ȣ���ؼ�����",
    "������ ��� �������", "�����..", "������������������������������������������������", " �ű⼭ �׵帳������", "�̺��� �����?", "���� ��Ȳ�������� ��¥ Ȳ���ϰ� ���̾ȳ�������",
    "��㸻�� ���Ӿ��Ͻ�?", "��","��","��","��" ,"�ĳĳ�", "������� �������Ͻǵ�", "�̾߱� ��Ǯ���", "�̾߱� ������ �̾߱� ������", "������ ���Ӹ��� ��ê�� �սô�.",
    "����~ ��ê�̴�!", "������ �Բ� ��԰��ִµ� �԰��׶����� ���ٰ� ���ھ������ݾ�!!!" , "���Դٰ� ����", "��ê�ϽǶ� ���ľȸԾ�߰ڴ�.", "�ʹ���մ�wwwwwww", "���滷��wwwwwww"};
    List<string> Game = new List<string>() {"���Ӱ̳����ϳפ���","���ӿ������Ͻ�?","���ӿ�����Ʈ����","��ȸ�������ô°� �����?","������������","������ ���Ͻó׿�","�װ� �׷��� �ϴ� �� �ƴѵ� ��",
    "���ε� �Թٸ���","�װǾƴ�","��� �ڿ� ���� �־��","���̴� �ϵ���ε� �̳����Ͻó�","Ŭ����Ȯ�� 0.1%�����ɷ� ����ϴ� �� �װ� 5�Ǹ���?","�ʹ����ϴ°žƴѰ�>?","���Ǹ�Ҹ��������پ˾���;;",
    "KDA 3/0/2����","�������� �������м�����", "���γ����� ���Ѵܼ��𤧤�", "�������ҷ��� ��ĳ�ϳ���?","�̰����� �̰�����", "���ӳ����� ���ϳ�...3���̳� �ߴµ�...",
        "���÷��̴��п� ������ �ٳ��ҽ��ϴ�.", "�������� ��ġ�� ����", "������ ���̴�."};


    [SerializeField]
    private Transform Content;
    [SerializeField]
    private TextMeshProUGUI chating = null;
    [SerializeField]
    private TextMeshProUGUI chatingContent = null;

    int chatingSpeed = 1; //ä�� �ö���� �ӵ�
    int NicknameColor = 0; //���� �г��� ����

    float defaultTime = 1f;
    float spawnTime = 0;
    bool bCommon;
    bool bVoice;
    bool bHumor;
    bool bGame;
    public void RandomColor()
    {
        Color color_title = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f);
        //string color_title_code = ColorUtility.ToHtmlStringRGBA(color_title);
        chating.color = color_title;
    }

    public void Show()
    {
        transform.SetParent(Content.transform);
        gameObject.SetActive(true);

    }



    public void UpdateShow()
    {

        if (GameManager.Instance.CurrentUser.humans < 0)
            return;

        int randomUser = Random.Range(0, twichName.Count);
        chating.text = (twichName[randomUser] + " : ");
        twichName.RemoveAt(randomUser);


        int randomChatingNumber = Random.Range(0, 5); // 0 , 1 , 2, 3

        if (randomChatingNumber == 1)
        {
            bCommon = RandomChance.GetThisChanceResult(50);
            if (!bCommon)
                randomChatingNumber = Random.Range(0, 4);
            int randomCommonChating = Random.Range(0, Chatingv.Count); //�Ϲ�ä��
            chatingContent.text = (Chatingv[randomCommonChating]);
            Chatingv.RemoveAt(randomCommonChating);
     
            Debug.Log("Chatingv");

        }
        else if (randomChatingNumber == 2)
        {
            bool bVoice = RandomChance.GetThisChanceResult(GameManager.Instance.CurrentUser.Voicepercentage);
            if (!bVoice)
                randomChatingNumber = Random.Range(0, 4);
            int randomVoiceChating = Random.Range(0, voice.Count); //��Ҹ�ä��
            chatingContent.text = (voice[randomVoiceChating]);

            Debug.Log("voice");

        }
        else if (randomChatingNumber == 3)
        {
            bool bHumor = RandomChance.GetThisChanceResult(GameManager.Instance.CurrentUser.Humorpercentage);
            if (!bHumor)
                randomChatingNumber = Random.Range(0, 4);
            int randomHumorChating = Random.Range(0, humor.Count); //����ä��
            chatingContent.text = (humor[randomHumorChating]);

            humor.RemoveAt(randomHumorChating);

            Debug.Log("humor");

        }
        else if (randomChatingNumber == 4)
        {

            bool bGame = RandomChance.GetThisChanceResult(GameManager.Instance.CurrentUser.Gamepercentage);
            if (!bGame)
                randomChatingNumber = Random.Range(0, 4);
            int randomGameChating = Random.Range(0, Game.Count); //����ä��
            chatingContent.text = (Game[randomGameChating]);
            Game.RemoveAt(randomGameChating);
    
            Debug.Log("Game");
            
         }
        else if(randomChatingNumber == 5 && GameManager.Instance.CurrentUser.humans < 1000)
        {
            int randomNewbiChating = Random.Range(0, viewers.Count);
            chatingContent.text = (viewers[randomNewbiChating]);
            viewers.RemoveAt(randomNewbiChating);
        }

        if(!bCommon && !bVoice && !bHumor && !bGame)
        {
            int randomCommonChating = Random.Range(0, Chatingv.Count); //�Ϲ�ä��
            chatingContent.text = (Chatingv[randomCommonChating]);
            Chatingv.RemoveAt(randomCommonChating);
        }
    }




}


  



