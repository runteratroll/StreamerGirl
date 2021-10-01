using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OneStudio : MonoBehaviour
{
    private void Awake()
    {
        Invoke("SceneNext", 1.5f);

    }

    private void SceneNext()
    {
        SceneManager.LoadScene("Start");
    }
}
