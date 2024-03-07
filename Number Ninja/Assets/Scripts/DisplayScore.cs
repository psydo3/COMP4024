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
            scoreText.text = "Good Job! You have scored "+ QuizManager.getUserScore() + "/10! Keep practising!";
        }
        if(userScore != null)
        {
            userScore.text = QuizManager.getUserScore()+"";
        }
    }

    /// <summary>
    /// Loads up the main game
    /// </summary>
    public void startNewGameOnClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    /// <summary>
    /// Loads up the feedback page
    /// </summary>
    public void showFeedbackOnClick()
    {
        SceneManager.LoadScene("UserFeedback");
    }
}
