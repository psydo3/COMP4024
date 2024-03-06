using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
    public int chosenIndex; // Answer index chosen by user
    public int incorrectIndex = 10; // Incorrect index chosen by user
    public static List<Feedback> feedbackList = new List<Feedback> { };
    
    void Start()
    {
        Debug.Log("Start called from QuizManager");

        loadQuizData();
        userScore = 0;
        evaluateAnswer(null, 10);
    }

    //Loads questions and answers from file
    void loadQuizData()
    {
        loadQuizDataFromJson();
        StartCoroutine(loadQuestion(questionNumber));
        StartCoroutine(loadAnswers(questionNumber));
    }

    public void loadQuizDataFromJson()
    {
        TextAsset quizJson = Resources.Load<TextAsset>("quizData"); // Load the JSON file from Resources
        quizData = JsonUtility.FromJson<QuizData>(quizJson.text); // Deserialize the JSON into the QuizData object

        Debug.Log("Quiz data loaded successfully");
    }
    
    public void evaluateAnswer(Question question, int chosenAnswer)
    {
        //Compare the answer the user has clicked with the answer from quiz data
        //When answer is correct
        if (chosenAnswer == correctAnswer)
        {
            Debug.Log(chosenIndex);

            // Change color of selected bubble to green
            if(chosenIndex == 0){
                bubbleImg1.color = new Color(114 / 255f, 210 / 255f, 135 / 255f); 
            } else if(chosenIndex == 1){
                bubbleImg2.color = new Color(114 / 255f, 210 / 255f, 135 / 255f);
            } else if(chosenIndex == 2){
                bubbleImg3.color = new Color(114 / 255f, 210 / 255f, 135 / 255f);
            } else if(chosenIndex == 3){
                bubbleImg4.color = new Color(114 / 255f, 210 / 255f, 135 / 255f);
            } else if(chosenIndex == 4){
                bubbleImg5.color = new Color(114 / 255f, 210 / 255f, 135 / 255f);
            } else if(chosenIndex == 5){
                bubbleImg6.color = new Color(114 / 255f, 210 / 255f, 135 / 255f);
            }

            // Add one to score 
            userScore += 1;
        }
        // When answer is incorrect
        else {
            // Change color of selected bubble to red
            if(incorrectIndex == 0){
                bubbleImg1.color = new Color(218 / 255f, 131 / 255f, 112 / 255f);
            } else if(incorrectIndex == 1){
                bubbleImg2.color = new Color(218 / 255f, 131 / 255f, 112 / 255f);
            } else if(incorrectIndex == 2){
                bubbleImg3.color = new Color(218 / 255f, 131 / 255f, 112 / 255f);
            } else if(incorrectIndex == 3){
                bubbleImg4.color = new Color(218 / 255f, 131 / 255f, 112 / 255f);
            } else if(incorrectIndex == 4){
                bubbleImg5.color = new Color(218 / 255f, 131 / 255f, 112 / 255f);
            } else if(incorrectIndex == 5){
                bubbleImg6.color = new Color(218 / 255f, 131 / 255f, 112 / 255f);
            }

        }

        if (scoreText != null)
        {
            scoreText.text = userScore.ToString();
        }

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
        yield return new WaitForSeconds(1);

        // Change color of bubble back to white
        bubbleImg1.color = Color.white;
        bubbleImg2.color = Color.white;
        bubbleImg3.color = Color.white;
        bubbleImg4.color = Color.white;
        bubbleImg5.color = Color.white;
        bubbleImg6.color = Color.white;

        Question question = quizData.questions[qNum];

        //Populate bubbles with answer options
        if (bubble1 != null && bubble2 != null && bubble3 != null
            && bubble4 != null && bubble5 != null && bubble6 != null)
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
    public void loadNextQuestionOnClick(int index)
    {
        incorrectIndex = index;
        Question question = quizData.questions[questionNumber];
        chosenIndex = question.correctAnswerIndex;
        chosenAnswer = int.Parse(question.answers[index]);
        evaluateAnswer(question, chosenAnswer);

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

    public void setQuizData(QuizData quizData)
    {
        this.quizData = quizData;
    }

    public int getQuestionNumber()
    {
        return questionNumber;
    }
}
