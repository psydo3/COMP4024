using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayUserFeedback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startNewGameOnClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void showNextFeedbackOnClick()
    {
        
    }

    public void showScorePageOnClick()
    {
        SceneManager.LoadScene("ScorePage");
    }
}
