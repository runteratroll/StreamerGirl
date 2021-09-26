using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    [SerializeField]
    private GameObject option = null;

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

    public void exitButton()
    {
        option.transform.position = Vector2.down * 1000;
    }
}
