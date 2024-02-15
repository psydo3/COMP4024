using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class startMain : MonoBehaviour
{
    public TMP_InputField inputField; // Reference to the input field
    public static string userName; // Variable to store the input

    public void LoadScene()
    {
        SceneManager.LoadScene("MainGame");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (inputField != null)
        {
            Debug.Log("from start  - test");
            // Add a listener to call the OnInputChange method whenever the text changes
            inputField.onValueChanged.AddListener(delegate { OnInputChange(inputField.text); });
        }
        else
        {
            Debug.Log("from else  - test");
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
