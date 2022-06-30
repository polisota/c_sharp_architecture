using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private int tryCount;
    public static int livesCount;
    public static int scoreCount;
    private MainMenu mainMenu;

    private Player player;

    void Start()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        livesCount = tryCount;
        scoreCount = 0;
    }

    public void Restart()
    {        
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            Destroy(obj);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(obj);
        }

        player.Respawn();
    }

    public void RestartLevel()
    {
        mainMenu.SwitchMenu();
        Restart();
        livesCount = tryCount;
        scoreCount = 0;
    }

    public bool CheckTry()
    {
        if (tryCount <= 0)
        {
            tryCount--;
            return true;
        }
        return false;
    }      

}