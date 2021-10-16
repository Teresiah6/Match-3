using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObstacles : Level
{
    public int numMoves;
    public GridRefScript.PieceType[] obstacleTypes;
    private int movesUsed = 0;
    private int numObstaclesLeft;
   
    // Start is called before the first frame update
    void Start()
    {
        type = LevelType.OBSTACLE;
        //loop through obstacle type to get obstacles of that type in the grid
        for(int i =0; i<obstacleTypes.Length; i++)
        {
            //increment number of obstacles left by num of pieces in the list
            numObstaclesLeft += gridRefScript.GetPiecesOfType(obstacleTypes[i]).Count;
        }
        //update teh hud
        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(numObstaclesLeft);
        hud.SetRemaining(numMoves);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnMove()
    {
        movesUsed++;
        hud.SetRemaining(numMoves - movesUsed);
        if(numMoves -movesUsed ==0 && numObstaclesLeft > 0)
        {
            GameLose();
        }
    }
    public override void OnPieceCleared(GamePiece piece)
    {
        //to help keep track of score
        base.OnPieceCleared(piece);
        for(int i =0; i<obstacleTypes.Length; i++)
        {
            if(obstacleTypes [i] == piece.Type)
            {
                numObstaclesLeft--;
               
                hud.SetTarget(numObstaclesLeft);
                if(numObstaclesLeft == 0)
                {
                    currentScore += 1000 * (numMoves - movesUsed);
                    hud.SetScore(currentScore);
                    
                    GameWin();

                }
            }
        }
    }
}
