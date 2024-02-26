using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int correctAnswer;
    public int chosenAnswer;
    int questionNumber = 0;
    
    //public TextMeshProUGUI displayScore;

    void Start()
    {
        Debug.Log("start called");

        //Call the appropriate function to load the quiz data

        loadQuizData();
        userScore = 0;
        evaluateAnswer(0);
    }

    void loadQuizData()
    {
        loadData();

        loadQuestion(quizData, questionNumber);
        loadAnswers(quizData, questionNumber);
    }

    public void loadData()
    {
        TextAsset quizJson = Resources.Load<TextAsset>("quizData"); // Load the JSON file from Resources
        quizData = JsonUtility.FromJson<QuizData>(quizJson.text); // Deserialize the JSON into the QuizData object
        //Add a log
        Debug.Log("quiz data loaded");
    }
    
    public void evaluateAnswer(int chosenAnswer)
    {
        //Add a log
        Debug.Log("Evaluate answer called - "+chosenAnswer+", "+correctAnswer);


        //Compare the answer the user has clicked with the answer from quiz data
        if (chosenAnswer == correctAnswer)
        {
            userScore += 1;
        }

        if (scoreText != null)
        {
            // Set the text of a UI Text component to the userInput
            scoreText.text = userScore.ToString();
        }
    }

    public int getUserScore()
    {
        return userScore;
    }

    public void loadQuestion(QuizData quizData, int qNum)
    {
        Question question = quizData.questions[qNum];
        questionText.text = question.questionText;
    }

    public void loadAnswers(QuizData quizData, int qNum)
    {
        Question question = quizData.questions[qNum];
        
        if(bubble1 != null && bubble2 != null && bubble3 != null 
            && bubble4 != null && bubble5 != null && bubble6 != null )
        {
            
        }
        bubble1.text = question.answers[0];
        bubble2.text = question.answers[1];
        bubble3.text = question.answers[2];
        bubble4.text = question.answers[3];
        bubble5.text = question.answers[4];
        bubble6.text = question.answers[5];

        correctAnswer = int.Parse(question.answers[question.correctAnswerIndex]);
    }

    public void loadNext(int index)
    {
        if (questionNumber == 2)
        {
            SceneManager.LoadScene("ScorePage");
        }
        Question question = quizData.questions[questionNumber];   
        chosenAnswer = int.Parse(question.answers[index]);
        evaluateAnswer(chosenAnswer);

        questionNumber++;
        loadQuestion(quizData, questionNumber);
        loadAnswers(quizData, questionNumber);
    }

    // Additional methods for quiz logic
}
