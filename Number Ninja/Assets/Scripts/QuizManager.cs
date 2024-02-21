using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public QuizData quizData; // Holds the loaded quiz data
    public TextMeshProUGUI scoreText;
    //Create a variable to track the user score
    int userScore;
    
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

    // Additional methods for quiz logic
}
