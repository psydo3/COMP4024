using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.ComponentModel.Design;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    QuizData quizData; // Holds the loaded quiz data

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI bubble1;
    public TextMeshProUGUI bubble2;
    public TextMeshProUGUI bubble3;
    public TextMeshProUGUI bubble4;
    public TextMeshProUGUI bubble5;
    public TextMeshProUGUI bubble6;

    public Image bubbleImg1;
    public Image bubbleImg2;
    public Image bubbleImg3;
    public Image bubbleImg4;
    public Image bubbleImg5;
    public Image bubbleImg6;

    public static int userScore; // Variable to track the user score
    int correctAnswer; // The correct answer to the question
    int chosenAnswer; // The answer selected by the user
    int questionNumber = 0; // Current question number
    public static List<Feedback> feedbackList = new List<Feedback> { };
    
    void Start()
    {
        Debug.Log("Start called from QuizManager");

        loadQuizData();
        userScore = 0;
    }

    /// <summary>
    /// Loads the quiz data.
    /// </summary>
    void loadQuizData()
    {
        if (quizData == null || quizData.questions.Length == 0)
        {
            loadQuizDataFromJson();
        }
        StartCoroutine(loadQuestion(questionNumber));
        StartCoroutine(loadAnswers(questionNumber));
    }

    /// <summary>
    /// Loads the quiz data from the json file.
    /// </summary>
    public void loadQuizDataFromJson()
    {
        TextAsset quizJson = Resources.Load<TextAsset>("quizData"); // Load the JSON file from Resources
        quizData = JsonUtility.FromJson<QuizData>(quizJson.text); // Deserialize the JSON into the QuizData object

        Debug.Log("Quiz data loaded successfully");
    }

    /// <summary>
    /// Evaluates the answer that the user has clicked.
    /// </summary>
    /// <param name="question">The current question.</param>
    /// <param name="chosenAnswer">The answer that the user has chosen.</param>
    /// <param name="chosenAnswerIndex">The index of the bubble that the user has clicked.</param>
    public void evaluateAnswer(Question question, int chosenAnswer, int chosenAnswerIndex)
    {
        //Compare the answer the user has clicked with the answer from quiz data
        if (chosenAnswer == correctAnswer)
        {
            //Since chosen answer is correct, set bubble colour to green
            setAnswerBubbleColour(new Color(114 / 255f, 210 / 255f, 135 / 255f), chosenAnswerIndex);

            userScore += 1;
        }
        else {
            //Since chosen answer is incorrect, set bubble colour to red
            setAnswerBubbleColour(new Color(218 / 255f, 131 / 255f, 112 / 255f), chosenAnswerIndex);
        }

        if (scoreText != null)
        {
            scoreText.text = userScore.ToString();
        }

        //Add the question and answer details for providing feedback 
        Feedback feedback = new(question.questionText, correctAnswer.ToString(), chosenAnswer.ToString());
        feedbackList.Add(feedback);
    }

    public static int getUserScore()
    {
        return userScore;
    }

    public IEnumerator loadQuestion(int qNum)
    {
        yield return new WaitForSeconds(1);
        Question question = quizData.questions[qNum];
        if(questionText != null)
        {
            questionText.text = question.questionText;
        }
    }

    public IEnumerator loadAnswers(int qNum)
    {
        Debug.Log("Entered loadAnswer()");

        yield return new WaitForSeconds(1);

        if (!isAnyBubbleImgNull())
        {
            // Change color of bubble back to white
            bubbleImg1.color = Color.white;
            bubbleImg2.color = Color.white;
            bubbleImg3.color = Color.white;
            bubbleImg4.color = Color.white;
            bubbleImg5.color = Color.white;
            bubbleImg6.color = Color.white;
        }

        Question question = quizData.questions[qNum];

        //Populate bubbles with answer options
        if (!isAnyBubbleNull())
        {
            bubble1.text = question.answers[0];
            bubble2.text = question.answers[1];
            bubble3.text = question.answers[2];
            bubble4.text = question.answers[3];
            bubble5.text = question.answers[4];
            bubble6.text = question.answers[5];
        }

        correctAnswer = int.Parse(question.answers[question.correctAnswerIndex]);
    }

    //Populate with next question and answer options
    public void loadNextQuestionOnClick(int clickedBubbleIndex)
    {
        Question question = quizData.questions[questionNumber];
        chosenAnswer = int.Parse(question.answers[clickedBubbleIndex]);
        evaluateAnswer(question, chosenAnswer, clickedBubbleIndex);

        questionNumber += 1;

        // Load the next question until all questions are answered
        if (questionNumber < quizData.questions.Length)
        {
            StartCoroutine (loadQuestion(questionNumber));
            StartCoroutine (loadAnswers(questionNumber));
        }
        else
        {
            SceneManager.LoadScene("ScorePage"); // Go to final score page once all the questions are answered
        }
    }

    void setAnswerBubbleColour(Color color, int chosenAnswerIndex)
    {
        if (!isAnyBubbleImgNull())
        {
            // Change color of selected bubble to the required color
            switch (chosenAnswerIndex)
            {
                case 0:
                    bubbleImg1.color = color;
                    break;
                case 1:
                    bubbleImg2.color = color;
                    break;
                case 2:
                    bubbleImg3.color = color;
                    break;
                case 3:
                    bubbleImg4.color = color;
                    break;
                case 4:
                    bubbleImg5.color = color;
                    break;
                case 5:
                    bubbleImg6.color = color;
                    break;
                default:
                    break;
            }
        }
    }

    bool isAnyBubbleNull()
    {
        return bubble1 == null || bubble2 == null || bubble3 == null
            || bubble4 == null || bubble5 == null || bubble6 == null;
    }
    bool isAnyBubbleImgNull()
    {
        return bubbleImg1 == null || bubbleImg2 == null || bubbleImg3 == null
            || bubbleImg4 == null || bubbleImg5 == null || bubbleImg6 == null;
    }

    public void setQuizData(QuizData quizData)
    {
        this.quizData = quizData;
    }

    public int getQuestionNumber()
    {
        return questionNumber;
    }
}