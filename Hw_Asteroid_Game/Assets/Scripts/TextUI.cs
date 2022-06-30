using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    [SerializeField] private Text livesNum;
    [SerializeField] private Text scoreNum;

    public void UpdateLives()
    {
        livesNum.text = SceneController.livesCount.ToString();
    }

    public void UpdateScore()
    {
        var score = SceneController.scoreCount;
        if (score/1000>=1000)
        {
            score = score / 1000000;
            scoreNum.text = score.ToString() + " M";
        }
        else if (score / 1000 < 1000 && score / 1000 > 0)
        {
            score = score / 1000;
            scoreNum.text = score.ToString() + " k";
        }
        else
        {
            scoreNum.text = score.ToString();
        }
        
        
        //scoreNum.text = SceneController.scoreCount.ToString();
    }
}
