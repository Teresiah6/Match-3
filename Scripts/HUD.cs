using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HUD : MonoBehaviour

{
    public Level level;
    public GameOver gameOver;
   
    public UnityEngine.UI.Text remainingText;
    public UnityEngine.UI.Text remainingSubtext;
    public UnityEngine.UI.Text targetText;
    public UnityEngine.UI.Text targetSubtext;
    public UnityEngine.UI.Text ScoreText;
    public UnityEngine.UI.Image[] stars;



    //index of start image currently being displayed
    private int StarIdx = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        //disable the star images
        for(int i =0; i<stars.Length; i++)
        {
            if (i == StarIdx)
            {
                stars[i].enabled = true;
                stars[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //set player score
    public void SetScore (int score)
    {
        ScoreText.text = score.ToString();
        int visibleStar = 0;
        if(score >= level.score1Star && score < level.score2Star)
        {
            visibleStar = 1;
        }
        else if(score>=level.score2Star && score < level.score3Star)
        {
            visibleStar = 2;

        }
        else if (score >= level.score3Star)
        {
            visibleStar = 3;
        }
        //enabling star based on index calculated
        for(int i =0; i<stars.Length; i++)
        {
            if (i < visibleStar)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
        //store index of the visible star
        StarIdx = visibleStar;
        
    }
    //update texts

    public void SetTarget (int target)
    {
        targetText.text = target.ToString();
    }
    public void SetRemaining (int remaining)
    {
        remainingText.text = remaining.ToString();
    }
    public void SetRemaining (string remaining)
    {
        remainingText.text = remaining;

    }
    public void SetLevelType(Level.LevelType type)
    {
        if(type == Level.LevelType.MOVES)
        {
            remainingSubtext.text = "moves remaining";
            targetSubtext.text = "target score";

        }else if(type == Level.LevelType.OBSTACLE)
        {
            remainingSubtext.text = "moves remaining";
            targetSubtext.text = "bubbles remaining";

        } else if(type == Level.LevelType.TIMER)
        {
            remainingSubtext.text = "time remaining";
            targetSubtext.text = "target score";
        }
    }
    public void OnGameWin(int score)
    {
        gameOver.ShowWin(score, StarIdx);
        if(StarIdx> PlayerPrefs.GetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name,0)){
            PlayerPrefs.SetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, StarIdx); //set stars as new stars


        }

        
    }
    public void OnGameLose()
    {
        gameOver.ShowLose();
        
    }
}
