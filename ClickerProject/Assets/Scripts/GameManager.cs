using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
 

    


   
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";
    private string BASIC_FILENAME = "/BasicFile.txt";
    private string basic = "";
    private bool basics= false;
    private bool sssss = false;
    [SerializeField]
    private User user = null;

        

    public User CurrentUser { get { return user; } }
    private UIManager uiManager = null;


    public UIManager UI
    {
        get
        {
            return uiManager;
        }
    }

    private void Awake()
    {
        SaveToJson();
        LoadFromJson();
        


        //persistentDataPath

        SAVE_PATH = Application.persistentDataPath + "/Save"; //����
        Debug.Log(Application.persistentDataPath);
        
        if (Directory.Exists(SAVE_PATH) == false) //���̺������� �������� �ʴ� �ٸ�
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        if (!basics)
        {
            basics =true;
            basic = JsonUtility.ToJson(user, true); //�ʱ���������

            File.WriteAllText(SAVE_PATH + BASIC_FILENAME, basic, System.Text.Encoding.UTF8); //��
        }

        

        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnEnergyPerSecond", 0f, 1f);
        LoadFromJson();

        uiManager = GetComponent<UIManager>();
        
    }

    

    private void EarnEnergyPerSecond()
    {
        //int i = 5;
        //int j = 1;
        foreach (Ability ability in user.soldierList)
        {
            user.energy += ability.mPs * ability.amount * 2;

            
        }

        if (UI == null)
        {
            return;
        }

        UI.UpdateHumansPanel();
        UI.UpdateEnergyPanel();

    }
    public void LoadFromJson()
    {
        string json = "";
        if (File.Exists(SAVE_PATH + SAVE_FILENAME) == true) //������ �����Ѵٸ�
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME); //�о�
            user = JsonUtility.FromJson<User>(json); //�������ٰ� ��
        }
    }

    public void ResetJson()
    {
          
        string json = " ";
        if(File.Exists(SAVE_PATH + BASIC_FILENAME) == true) //Basic_text
        {
            
            json = File.ReadAllText(SAVE_PATH + BASIC_FILENAME); //�ϱऱ
            user = JsonUtility.FromJson<User>(json); //�������ٰ�����
        }
    }
    public void SaveToJson()
    {
        Debug.Log("���̺��߽��ϴ�!");
        string json = JsonUtility.ToJson(user, true); //��������
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8); //���Ͽ��ٰ� ���������� ���´� �װɷ�
    }


    private void OnApplicationQuit()
    {
        SaveToJson();
    }

}