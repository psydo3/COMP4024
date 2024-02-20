using TMPro;
using UnityEngine;


public class displayUserName : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (displayText != null)
        {
            // Set the text of a UI Text component to the userInput
            displayText.text = "Hi "+StartMain.getUserName()+"!";

            scoreText.text = QuizManager.userScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
