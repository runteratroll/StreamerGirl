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

    public User CurrentUser { get { return user; } } //편집은 못하지만 꺼낼순 있음 get은 함수같음
    private void Awake()
    {
        
        //안드로이드 빌드시  Application.persistentDataPath로 수정
        SAVE_PATH = Application.dataPath + "/Save";
        //이폴더가 존재하지 않을 때는

        if (Directory.Exists(SAVE_PATH) == false)
        {
            Directory.CreateDirectory(SAVE_PATH);
        }

        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnEnergyPerSecond", 0f, 1f); //1초마다 
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
        string json = JsonUtility.ToJson(user, true); //유저를 Json으로 바꿈
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }
}