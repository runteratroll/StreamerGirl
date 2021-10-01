//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;

//public class DataController : MonoSingleton<DataController>
//{
//    private string SAVE_PATH = "";
//    private string SAVE_FILENAME = "/SaveFile.txt";


//    private void Awake()
//    {
//        SAVE_PATH = Application.persistentDataPath + "/Save"; //파일
//        Debug.Log(Application.persistentDataPath);

//        if (Directory.Exists(SAVE_PATH) == false) //세이브파일이 존재하지 않는 다면
//        {
//            Directory.CreateDirectory(SAVE_PATH);
//        }

//        InvokeRepeating("SaveToJson", 1f, 60f);
//        InvokeRepeating("EarnEnergyPerSecond", 0f, 1f);
//        LoadFromJson();
//    }
//    public void LoadFromJson()
//    {
//        string json = "";
//        if (File.Exists(SAVE_PATH + SAVE_FILENAME) == true) //파일이 존재한다면
//        {
//            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME); //읽어
//            user = JsonUtility.FromJson<User>(json); //유저에다가 써
//        }
//    }
//    public void SaveToJson()
//    {
//        Debug.Log("세이브했습니다!");
//        string json = JsonUtility.ToJson(user, true); //유젖정보
//        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8); //파일에다가 유저정보를 적는다 그걸로
//    }


//    private void /OnApplicationQuit()
//    {
//        SaveToJson();
//    }


//}
