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
}
