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
        
        SAVE_PATH = Application.persistentDataPath + "/Save";
        if (Directory.Exists(SAVE_PATH) == false)
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        InvokeRepeating("SaveToJson", 0f, 60f);
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
    private void LoadFromJson()
    {
        string json = "";
        if (File.Exists(SAVE_PATH + SAVE_FILENAME) == true)
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
    }
    public void SaveToJson()
    {
        Debug.Log("세이브했습니다!");
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }


    private void OnApplicationQuit()
    {
        SaveToJson();
    }

}