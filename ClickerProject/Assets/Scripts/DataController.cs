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
//        SAVE_PATH = Application.persistentDataPath + "/Save"; //����
//        Debug.Log(Application.persistentDataPath);

//        if (Directory.Exists(SAVE_PATH) == false) //���̺������� �������� �ʴ� �ٸ�
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
//        if (File.Exists(SAVE_PATH + SAVE_FILENAME) == true) //������ �����Ѵٸ�
//        {
//            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME); //�о�
//            user = JsonUtility.FromJson<User>(json); //�������ٰ� ��
//        }
//    }
//    public void SaveToJson()
//    {
//        Debug.Log("���̺��߽��ϴ�!");
//        string json = JsonUtility.ToJson(user, true); //��������
//        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8); //���Ͽ��ٰ� ���������� ���´� �װɷ�
//    }


//    private void /OnApplicationQuit()
//    {
//        SaveToJson();
//    }


//}
