using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI userScore;
    public Button tryAgainButton;
    public Button feedbackButton;

    // Start is called before the first frame update
    void Start()
    {
        if(scoreText != null)
        {
            scoreText.text = "Congrats";
        }
        if(userScore != null)
        {
            userScore.text = QuizManager.getUserScore()+"";
        }
    }

    public void startNewGameOnClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void showFeedbackOnClick()
    {
        SceneManager.LoadScene("UserFeedback");
    }
}
