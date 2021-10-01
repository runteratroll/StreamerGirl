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

        SAVE_PATH = Application.persistentDataPath + "/Save"; //파일
        Debug.Log(Application.persistentDataPath);
        
        if (Directory.Exists(SAVE_PATH) == false) //세이브파일이 존재하지 않는 다면
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        if (!basics)
        {
            basics =true;
            basic = JsonUtility.ToJson(user, true); //초기유저내용

            File.WriteAllText(SAVE_PATH + BASIC_FILENAME, basic, System.Text.Encoding.UTF8); //씀
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
        if (File.Exists(SAVE_PATH + SAVE_FILENAME) == true) //파일이 존재한다면
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME); //읽어
            user = JsonUtility.FromJson<User>(json); //유저에다가 써
        }
    }

    public void ResetJson()
    {
          
        string json = " ";
        if(File.Exists(SAVE_PATH + BASIC_FILENAME) == true) //Basic_text
        {
            
            json = File.ReadAllText(SAVE_PATH + BASIC_FILENAME); //일긍ㅁ
            user = JsonUtility.FromJson<User>(json); //유저에다가기입
        }
    }
    public void SaveToJson()
    {
        Debug.Log("세이브했습니다!");
        string json = JsonUtility.ToJson(user, true); //유젖정보
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8); //파일에다가 유저정보를 적는다 그걸로
    }


    private void OnApplicationQuit()
    {
        SaveToJson();
    }

}