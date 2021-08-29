using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoader : MonoBehaviour
{
    int buildIndex; 
    private void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;  
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(7);
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(buildIndex + 1);   
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); 
    } 
    public void ReloadScene()
    {
        SceneManager.LoadScene(buildIndex); 
    }
    public void QuitGame()
    {
        Application.Quit();   
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }
}
