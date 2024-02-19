using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public QuizData quizData; // Holds the loaded quiz data
    //Create a variable to track the user score

    void Start()
    {
        //Call the appropriate function to load the quiz data
        
        //Add a log
    }

    void loadQuizData()
    {
        TextAsset quizJson = Resources.Load<TextAsset>("quizData"); // Load the JSON file from Resources
        quizData = JsonUtility.FromJson<QuizData>(quizJson.text); // Deserialize the JSON into the QuizData object

        //Add a log
    }

    void evaluateAnswer(int answer)
    {
        //Add a log

        //Compare the answer the user has clicked with the answer from quiz data
        
        //Increase the score if correct
    }

    // Additional methods for quiz logic
}
