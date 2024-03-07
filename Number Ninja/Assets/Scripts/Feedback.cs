using System.Collections.Generic;

public class Feedback
{
    public string questionText;
    public string chosenAnswer;
    public string correctAnswer;
    public bool isAnswerCorrect;

    public Feedback(string questionText, string chosenAnswer, string correctAnswer)
    {
        this.questionText = questionText;
        this.chosenAnswer = chosenAnswer;
        this.correctAnswer = correctAnswer;

        // If the answer that the user chooses is the correct answer, set the flag to True. Else set it to False
        isAnswerCorrect = (chosenAnswer == correctAnswer); 
    }
}