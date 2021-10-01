using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Start : MonoBehaviour
{
    [SerializeField]
    private GameObject option = null;
    [SerializeField]
    private GameObject StartNewAndLoad = null;
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";
    private void Awake()
    {
        //DontDestroyOnLoad(option);
        SAVE_PATH = Application.persistentDataPath + "/Save"; //파일
        Debug.Log(Application.persistentDataPath);

        if (Directory.Exists(SAVE_PATH) == false) //세이브파일이 존재하지 않는 다면
        {
            Directory.CreateDirectory(SAVE_PATH);
        }



    }

    
    public void StartClick()
    {
   
        SceneManager.LoadScene("SampleScene");


    }

    public void StartNew()
    {



        GameManager.Instance.ResetJson();

        SceneManager.LoadScene("SampleScene"); //그리고 씬을 넘어간다 돈디스트로이 오브젝트


    }


    public void Option()
    {
        option.transform.position = Vector2.zero;
        
    }

    public void NewAndLoad()
    {
        StartNewAndLoad.transform.position = Vector2.zero;
        StartNewAndLoad.transform.position = Vector2.up * 0.5f;
    }

    public void exitNewAndLoad()
    {
        StartNewAndLoad.transform.position = Vector2.down * 100;
    }
    public void exitButton()
    {
        option.transform.position = Vector2.down * 1000;
    }
}
