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
    /// Loads up the main game.
    /// </summary>
    //Starts the game again
    public void startNewGameOnClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    /// <summary>
    /// Loads the next question feedback
    /// </summary>
    //Next question feedback
    public void showNextFeedbackOnClick()
    {
        if(questionNumber >= 0 && questionNumber < totalNumQuestions-1)
        {
            questionNumber += 1;
            setFeedbackFields(questionNumber);
        }
    }

    /// <summary>
    /// Loads the previous question feedback
    /// </summary>
    //Previous question feedback
    public void showPrevFeedbackOnClick()
    {
        if (questionNumber >= 1 && questionNumber < totalNumQuestions)
        {
            questionNumber -= 1;
            setFeedbackFields(questionNumber);
        }
    }

    /// <summary>
    /// Loads the score page
    /// </summary>
    //Load score page
    public void showScorePageOnClick()
    {
        SceneManager.LoadScene("ScorePage");
    }

    /// <summary>
    /// Sets up the feedback
    /// </summary>
    /// <param>
    /// int question number
    ///</param>
    //Appropriate tick or cross images are chosen depending on user answer
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
    /// Checks if any text on the feedback page is null
    /// </summary>
    /// <return>
    /// bool returns true if question text, chosen answer text or correct answer text are null
    /// </return>
    bool isAnyFeedbackFieldNull()
    {
        return questionText == null || chosenAnsText == null || correctAnsText == null;
    }

    /// <summary>
    /// Checks the images are null
    /// </summary>
    /// <return>
    /// bool returns true if images are null
    /// </return>
    bool isAnyAnsImgFieldNull()
    {
        return chosenAnsImage == null || correctAnsImage == null;
    }

    /// <summary>
    /// Gets the total number of questions
    /// </summary>
    /// <return>
    /// int returns total number of questions
    /// </return>
    public int getTotalNumQuestions()
    {
        return totalNumQuestions;
    }

    /// <summary>
    /// Sets the total number of questions
    /// </summary>
    public void setTotalNumQuestions(int totalNumQuestions)
    {
        this.totalNumQuestions = totalNumQuestions;
    }

    /// <summary>
    /// Gets question number
    /// </summary>
    /// <return>
    /// int returns question number
    /// </return>
    public int getQuestionNumber()
    {
        return questionNumber;
    }

    /// <summary>
    /// Sets question number
    /// </summary>
    public void setQuestionNumber(int questionNumber)
    {
        this.questionNumber = questionNumber;
    }
}
