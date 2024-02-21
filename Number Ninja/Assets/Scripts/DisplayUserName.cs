using TMPro;
using UnityEngine;


public class displayUserName : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    // Start is called before the first frame update
    void Start()
    {
        if (displayText != null)
        {
            // Set the text of a UI Text component to the userInput
            displayText.text = "Hi "+StartMain.getUserName()+"!";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
