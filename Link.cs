using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Link : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        
    }
    public void LoadScene2(string name2)
    {
        SceneManager.LoadScene(name2);
        if (Time.timeScale == 1.0f)
            Time.timeScale = 0.0f;
    }
}
