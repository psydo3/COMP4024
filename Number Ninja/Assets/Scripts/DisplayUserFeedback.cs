using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayUserFeedback : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI chosenAnsText;
    public TextMeshProUGUI correctAnsText;
    public Image chosenAnsImage;
    public Image correctAnsImage;
    public Sprite tickSprite;
    public Sprite crossSprite;

    int questionNumber = 0;
    int totalNumQuestions;

    void Start()
    {
        setFeedbackFields(questionNumber = 0);
        totalNumQuestions = QuizManager.feedbackList.Count;
    }

    public void startNewGameOnClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void showNextFeedbackOnClick()
    {
        if(questionNumber >= 0 && questionNumber < totalNumQuestions-1)
        {
            questionNumber += 1;
            setFeedbackFields(questionNumber);
        }
    }

    public void showPrevFeedbackOnClick()
    {
        if (questionNumber >= 1 && questionNumber < totalNumQuestions)
        {
            questionNumber -= 1;
            setFeedbackFields(questionNumber);
        }
    }

    public void showScorePageOnClick()
    {
        SceneManager.LoadScene("ScorePage");
    }

    void setFeedbackFields(int questionNumber)
    {
        int qNumToDisplay = questionNumber + 1;
        questionText.text = "Q"+ qNumToDisplay + ". " + QuizManager.feedbackList[questionNumber].questionText;
        chosenAnsText.text = QuizManager.feedbackList[questionNumber].chosenAnswer;
        correctAnsText.text = QuizManager.feedbackList[questionNumber].correctAnswer;

        if (QuizManager.feedbackList[questionNumber].isCorrect)
        {
            chosenAnsImage.sprite = tickSprite;
            correctAnsImage.sprite = tickSprite;
        }
        else
        {
            chosenAnsImage.sprite = crossSprite;
            correctAnsImage.sprite = tickSprite;
        }
    }
}
