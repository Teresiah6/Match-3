using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject screenParent;
    public GameObject scoreParent;
    public UnityEngine.UI.Text loseText;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Image[] stars;
    // Start is called before the first frame update
    void Start()
    {
        //deactivate the screen object
        screenParent.SetActive(false);
        //hide start images
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowLose()
    {
        screenParent.SetActive(true);
        scoreParent.SetActive(false);
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.Play("GameOverShow");
        }
    }
    //show screen when we win the game
    public void ShowWin(int score, int starCount)
    {
        screenParent.SetActive(true);
        loseText.enabled = false;
        scoreText.text = score.ToString();
        scoreText.enabled = false;

        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.Play("GameOverShow");
        }
        StartCoroutine(ShowWinCoroutine(starCount));
    }
    //show stars one at a time - use coroutine
    private IEnumerator ShowWinCoroutine(int starCount)
    {
        yield return new WaitForSeconds(0.5f);
        if (starCount < stars.Length)
        {
            for (int i = 0; i <= starCount; i++)
            {
                stars[i].enabled = true;
                if (i > 0)
                {
                    stars[i - 1].enabled = false;
                }
                yield return new WaitForSeconds(0.5f);

            }

        }
        scoreText.enabled = true;
    }
    public void OnReplayClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void onDoneClicked()
    {

        //load the level select scene 
        UnityEngine.SceneManagement.SceneManager.LoadScene("levelSelect");
    }
}
