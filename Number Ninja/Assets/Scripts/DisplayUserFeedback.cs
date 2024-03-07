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

    //Starts the game again
    public void startNewGameOnClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    //Next question feedback
    public void showNextFeedbackOnClick()
    {
        if(questionNumber >= 0 && questionNumber < totalNumQuestions-1)
        {
            questionNumber += 1;
            setFeedbackFields(questionNumber);
        }
    }

    //Previous question feedback
    public void showPrevFeedbackOnClick()
    {
        if (questionNumber >= 1 && questionNumber < totalNumQuestions)
        {
            questionNumber -= 1;
            setFeedbackFields(questionNumber);
        }
    }

    //Load score page
    public void showScorePageOnClick()
    {
        SceneManager.LoadScene("ScorePage");
    }

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

    bool isAnyFeedbackFieldNull()
    {
        return questionText == null || chosenAnsText == null || correctAnsText == null;
    }

    bool isAnyAnsImgFieldNull()
    {
        return chosenAnsImage == null || correctAnsImage == null;
    }

    public int getTotalNumQuestions()
    {
        return totalNumQuestions;
    }

    public void setTotalNumQuestions(int totalNumQuestions)
    {
        this.totalNumQuestions = totalNumQuestions;
    }

    public int getQuestionNumber()
    {
        return questionNumber;
    }

    public void setQuestionNumber(int questionNumber)
    {
        this.questionNumber = questionNumber;
    }
}
