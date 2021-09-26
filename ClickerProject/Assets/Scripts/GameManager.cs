using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";
    [SerializeField]
    private User user = null;

    private UIManager uiManager = null;

    public UIManager UI { get { return uiManager; } }

    public User CurrentUser { get { return user; } } //������ �������� ������ ���� get�� �Լ�����
    private void Awake()
    {
        
        //�ȵ���̵� �����  Application.persistentDataPath�� ����
        SAVE_PATH = Application.dataPath + "/Save";
        //�������� �������� ���� ����

        if (Directory.Exists(SAVE_PATH) == false)
        {
            Directory.CreateDirectory(SAVE_PATH);
        }

        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnEnergyPerSecond", 0f, 1f); //1�ʸ��� 
        LoadFromJson();
        uiManager = GetComponent<UIManager>();

    }

    private void LoadFromJson()
    {
        string json = "";
        if (File.Exists(SAVE_FILENAME) == true)
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
    }

    private void EarnEnergyPerSecond()
    {
        //int i = 5;
        //int j = 1;
        foreach (Ability ability in user.soldierList)
        {
            user.energy += ability.mPs * ability.amount * 2;

 
        }
        
        UI.UpdateEnergyPanel();
        UI.UpdateHumansPanel();

    }


    
  
    private void SaveToJson()
    {
        SAVE_PATH = Application.dataPath + "/Save";
        string json = JsonUtility.ToJson(user, true); //������ Json���� �ٲ�
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }
}