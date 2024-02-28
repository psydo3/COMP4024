using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static int userScore; // Variable to track the user score
    int correctAnswer; // The correct answer to the question
    int chosenAnswer; // The answer selected by the user
    int questionNumber = 0; // Current question number

    void Start()
    {
        Debug.Log("Start called from QuizManager");

        loadQuizData();
        userScore = 0;
        evaluateAnswer(0);
    }

    void loadQuizData()
    {
        loadQuizDataFromJson();
        loadQuestion(questionNumber);
        loadAnswers(questionNumber);
    }

    public void loadQuizDataFromJson()
    {
        TextAsset quizJson = Resources.Load<TextAsset>("quizData"); // Load the JSON file from Resources
        quizData = JsonUtility.FromJson<QuizData>(quizJson.text); // Deserialize the JSON into the QuizData object

        Debug.Log("Quiz data loaded successfully");
    }
    
    public void evaluateAnswer(int chosenAnswer)
    {
        //Compare the answer the user has clicked with the answer from quiz data
        if (chosenAnswer == correctAnswer)
        {
            userScore += 1;
        }

        if (scoreText != null)
        {
            scoreText.text = userScore.ToString();
        }
    }

    public static int getUserScore()
    {
        return userScore;
    }

    public void loadQuestion(int qNum)
    {
        Question question = quizData.questions[qNum];
        questionText.text = question.questionText;
    }

    public void loadAnswers(int qNum)
    {
        Question question = quizData.questions[qNum];

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

    public void loadNextQuestionOnClick(int index)
    {
        Question question = quizData.questions[questionNumber];   
        chosenAnswer = int.Parse(question.answers[index]);
        evaluateAnswer(chosenAnswer);

        questionNumber += 1;

        // Load the next question until all questions are answered
        if (questionNumber < quizData.questions.Length)
        {
            loadQuestion(questionNumber);
            loadAnswers(questionNumber);
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
}
