using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void NextScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

     public void QuitGame()
    {
        Application.Quit();
        Debug.Log("application closed");
    }
}
