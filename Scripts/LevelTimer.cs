using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : Level
{
    public int timeInseconds;
    public int targetScore;

    private float timer;
    private bool timeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        type = LevelType.TIMER;
        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetRemaining(string.Format("{0}:{1:00}", timeInseconds/60,timeInseconds%60));

               

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeOut)
        {
            timer += Time.deltaTime;
            hud.SetRemaining(string.Format("{0}:{1:00}", (int)Mathf.Max((timeInseconds-timer) / 60,0), (int)Mathf.Max((timeInseconds-timer) % 60,0)));

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
}
