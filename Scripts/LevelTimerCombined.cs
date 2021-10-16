using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimerCombined : Level
{
    public int timeInseconds;
    public int targetScore;

    private float timer;
    private bool timeOut = false;
    // Start is called before the first frame update
    private int numObstaclesLeft;
    public GridRefScript.PieceType[] obstacleTypes;
    void Start()
    {
        
        type = LevelType.TIMERCOMBINED;
        for (int i = 0; i < obstacleTypes.Length; i++)
        {
            //increment number of obstacles left by num of pieces in the list
            numObstaclesLeft += gridRefScript.GetPiecesOfType(obstacleTypes[i]).Count;
        }
        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(targetScore);
      
        hud.SetRemaining(string.Format("{0}:{1:00}", timeInseconds / 60, timeInseconds % 60));

    }

    // Update is called once per frame
    void Update()
    {
        if(!timeOut)
        {
            timer += Time.deltaTime;
            hud.SetRemaining(string.Format("{0}:{1:00}", (int)Mathf.Max((timeInseconds - timer) / 60, 0), (int)Mathf.Max((timeInseconds - timer) % 60, 0)));

            if (timeInseconds - timer <= 0)
            {
                //check if we reached the target score
                if (currentScore >= targetScore)
                {
                    GameWin();
                }
                else
                {
                    GameLose();
                }
                timeOut = true;
            }

        }

    }
    public override void OnPieceCleared(GamePiece piece)
    {
        //to help keep track of score
        base.OnPieceCleared(piece);
        for (int i = 0; i < obstacleTypes.Length; i++)
        {
            if (obstacleTypes[i] == piece.Type)
            {
                numObstaclesLeft--;
                hud.SetTarget(targetScore);
                if (numObstaclesLeft == 0 && currentScore >= targetScore)
                {
                    currentScore += 1000 * (timeInseconds);
                    hud.SetScore(currentScore);
                    GameWin();
                }
            }
        }
    }
    
}
