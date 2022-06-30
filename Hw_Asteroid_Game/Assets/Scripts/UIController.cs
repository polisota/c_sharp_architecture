using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private TextUI textUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.GetComponent<MainMenu>().SwitchMenu();
        }

        textUI.UpdateLives();
        textUI.UpdateScore();
    }
    
}
