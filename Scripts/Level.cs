using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    //possible level types
    public enum LevelType
    {
        TIMER, OBSTACLE, MOVES,TIMERCOMBINED,
    }
    public GridRefScript gridRefScript;
    public HUD hud;
    //way to determine how well player does
    public int score1Star;
    public int score2Star;
    public int score3Star;
    protected LevelType type;

    public LevelType Type
    {
        get { return type; }

    }
    protected int currentScore;
    protected bool didWin;
    // Start is called before the first frame update
    void Start()
    {
        hud.SetScore(currentScore);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void GameWin()
    {

        gridRefScript.GameOver();
        didWin = true;
        StartCoroutine(WaitForGridFill());

    }
    public virtual void GameLose()
    {

        gridRefScript.GameOver();
        didWin = false;
        StartCoroutine(WaitForGridFill());

    }
    //keeping track of what the player is doing 
    public virtual void OnMove()
    {
        //   Debug.Log("You Moved");
        //gridRefScript.GameOver();

    }
    public virtual void OnPieceCleared(GamePiece piece)
    {
        //update score
        currentScore += piece.score;
        hud.SetScore(currentScore);
    }
    //waiting for the grid to fill
    protected virtual IEnumerator WaitForGridFill() //protected because inheritance
    {
        while (gridRefScript.IsFilling)
        {
            yield return 0;
        }
        //once done filling we check if we won or lost
        if (didWin)
        {
            hud.OnGameWin(currentScore);
        }
        else
        {
            hud.OnGameLose();
        }
    }
}
