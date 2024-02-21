using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public QuizData quizData; // Holds the loaded quiz data
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI questionText;

    public TextMeshProUGUI bubble1;
    public TextMeshProUGUI bubble2;
    public TextMeshProUGUI bubble3;
    public TextMeshProUGUI bubble4;
    public TextMeshProUGUI bubble5;
    public TextMeshProUGUI bubble6;
    //Create a variable to track the user score
    int userScore;
    int correctAnswer;
    
    //public TextMeshProUGUI displayScore;

    void Start()
    {
        Debug.Log("start called");
        //Call the appropriate function to load the quiz data
        loadQuizData();
        evaluateAnswer(0);
    }

    void loadQuizData()
    {
        TextAsset quizJson = Resources.Load<TextAsset>("quizData"); // Load the JSON file from Resources
        quizData = JsonUtility.FromJson<QuizData>(quizJson.text); // Deserialize the JSON into the QuizData object
        //Add a log
        Debug.Log("quiz data loaded");

        loadQuestion();
        loadAnswers();
    }

    void evaluateAnswer(int answer)
    {
        //Add a log
        Debug.Log("Evaluate answer called");

        //Compare the answer the user has clicked with the answer from quiz data
        userScore = 1;
        if (scoreText != null)
        {
            // Set the text of a UI Text component to the userInput
            scoreText.text = userScore.ToString();
        }

        //Increase the score if correct
    }

    void loadQuestion()
    {
        Question question = quizData.questions[0];
        questionText.text = question.questionText;
    }

    void loadAnswers(){
        Question answers = quizData.questions[0];
        
        bubble1.text = answers.answers[0];
        bubble2.text = answers.answers[1];
        bubble3.text = answers.answers[2];
        bubble4.text = answers.answers[3];
        bubble5.text = answers.answers[4];
        bubble6.text = answers.answers[5];

        correctAnswer = answers.correctAnswerIndex;
    }

    // Additional methods for quiz logic
}
