using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour

{
    [System.Serializable]
    public struct ButtonPlayerPrefs
    {
        public GameObject gameObject;
        public string playerPrefKey;
    }
    //array of the structs
    public ButtonPlayerPrefs[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        //loop through the array buttons and get the highest score for each one
        //show or hide stars accordingly
        for(int i =0; i<buttons.Length; i++)
        {
            int score = PlayerPrefs.GetInt(buttons[i].playerPrefKey, 0);
            for(int starIdx =1; starIdx<=3; starIdx++)
            {
                Transform star = buttons[i].gameObject.transform.Find("star" + starIdx);
                if(starIdx <= score)
                {
                    star.gameObject.SetActive(true);
                }
                else
                {
                    //if they havent achieved the star ranking
                    star.gameObject.SetActive(false);
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonPressed(string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}
