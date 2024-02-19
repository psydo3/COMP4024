[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;
}

[System.Serializable]
public class QuizData
{
    public Question[] questions;
}

