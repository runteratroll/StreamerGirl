using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    [SerializeField]
    private GameObject option = null;
    [SerializeField]
    private GameObject StartNewAndLoad = null;

    private void Awake()
    {
        DontDestroyOnLoad(option);
        
    }

    public void StartClick()
    {

        SceneManager.LoadScene("SampleScene");

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
