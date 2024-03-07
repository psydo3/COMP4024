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

    /// <summary>
    /// Starts a new game.
    /// </summary>
    public void startNewGameOnClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    /// <summary>
    /// Loads the feedback for the next question.
    /// </summary>
    public void showNextFeedbackOnClick()
    {
        if(questionNumber >= 0 && questionNumber < totalNumQuestions-1)
        {
            questionNumber += 1;
            setFeedbackFields(questionNumber);
        }
    }

    /// <summary>
    /// Loads the feedback for the previous question
    /// </summary>
    public void showPrevFeedbackOnClick()
    {
        if (questionNumber >= 1 && questionNumber < totalNumQuestions)
        {
            questionNumber -= 1;
            setFeedbackFields(questionNumber);
        }
    }

    /// <summary>
    /// Loads the score page.
    /// </summary>
    public void showScorePageOnClick()
    {
        SceneManager.LoadScene("ScorePage");
    }

    /// <summary>
    /// Sets the feedback fields in Unity UI.
    /// </summary>
    /// <param name="questionNumber">The question number that the feedback is set for.</param>
    void setFeedbackFields(int questionNumber)
    {
        int qNumToDisplay = questionNumber + 1;
        if (!isAnyFeedbackFieldNull())
        {
            questionText.text = "Q" + qNumToDisplay + ". " + QuizManager.feedbackList[questionNumber].questionText;
            chosenAnsText.text = QuizManager.feedbackList[questionNumber].chosenAnswer;
            correctAnsText.text = QuizManager.feedbackList[questionNumber].correctAnswer;
        }

        if (!isAnyAnsImgFieldNull())
        {
            if (QuizManager.feedbackList[questionNumber].isAnswerCorrect)
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

    /// <summary>
    /// Checks if any feedback field is null.
    /// </summary>
    /// <returns>Boolean value indicating if any of the feedback fields is null.</returns>
    bool isAnyFeedbackFieldNull()
    {
        return questionText == null || chosenAnsText == null || correctAnsText == null;
    }

    /// <summary>
    /// Checks if any answer image field is null.
    /// </summary>
    /// <returns>Boolean value indicating if any of the feedback fields is null.</returns>
    bool isAnyAnsImgFieldNull()
    {
        return chosenAnsImage == null || correctAnsImage == null;
    }

    /// <summary>
    /// Getter funciton for the total number of questions.
    /// </summary>
    /// <returns>Integer value of the total number of questions.</returns>
    public int getTotalNumQuestions()
    {
        return totalNumQuestions;
    }

    /// <summary>
    /// Setter functoin for the total number of questions
    /// </summary>
    /// <param name="totalNumQuestions">The total number of questions in quiz data.</param>
    public void setTotalNumQuestions(int totalNumQuestions)
    {
        this.totalNumQuestions = totalNumQuestions;
    }

    /// <summary>
    /// Getter function for the current question number.
    /// </summary>
    /// <returns>Integer value of the current question number.</returns>
    public int getQuestionNumber()
    {
        return questionNumber;
    }

    /// <summary>
    /// Setter function for the current question number.
    /// </summary>
    /// <param name="questionNumber">The current question number.</param>
    public void setQuestionNumber(int questionNumber)
    {
        this.questionNumber = questionNumber;
    }
}
