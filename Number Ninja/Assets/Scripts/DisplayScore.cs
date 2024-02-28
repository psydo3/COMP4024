using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI userScore;

    // Start is called before the first frame update
    void Start()
    {
        if(scoreText != null)
        {
            scoreText.text = "Congrats";
        }
        if(userScore != null)
        {
            userScore.text = QuizManager.getUserScore()+"";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
