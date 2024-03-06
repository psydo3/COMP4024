using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMain : MonoBehaviour
{
    public TMP_InputField inputField; // Reference to the input field
    public TextMeshProUGUI displayErrorField; //Reference to the text field for errors
    public static string userName; // Variable to store the input

    public void LoadScene()
    {
        //Start the game if name is not left null
        if (userName != "" && userName != null)
        {
            SceneManager.LoadScene("MainGame");
        }
        else
        {
            Debug.Log("No input given!");
            //Name is left null so give error message
            if(displayErrorField != null)
            {
                displayErrorField.text = "No input given!";
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (inputField != null)
        {
            // Add a listener to call the OnInputChange method whenever the text changes
            inputField.onValueChanged.AddListener(delegate { OnInputChange(inputField.text); });
        }
    }

    public void OnInputChange(string text)
    {
        userName = text;
        Debug.Log("User Input: " + userName);
    }

    public static string getUserName()
    {
        return userName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
