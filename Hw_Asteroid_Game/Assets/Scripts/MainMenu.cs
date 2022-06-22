using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;    
    private SceneController sceneController;
  

    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
    }

    public void SwitchMenu()
    {        
        menu.SetActive(!menu.activeSelf);
    }    

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Restart()
    {
        sceneController.RestartLevel();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
