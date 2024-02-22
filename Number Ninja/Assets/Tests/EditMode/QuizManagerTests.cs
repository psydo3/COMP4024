using NUnit.Framework;
using UnityEngine;

public class QuizManagerTests
{
    
    [Test]
    public void evaluateAnswer_IncrementsScore_WhenCorrect()
    {
        var quizManager = new GameObject().AddComponent<QuizManager>();
        quizManager.quizData = new QuizData
        {
            questions = new Question[]
            {
                new Question
                {
                    questionText = "1+1",
                    answers = new string[] { "1", "2", "3", "4", "5", "6" },
                    correctAnswerIndex = 1
                }
            }
        };
        quizManager.loadAnswers(quizManager.quizData);
        quizManager.evaluateAnswer(2);

        Assert.AreEqual(1, quizManager.getUserScore()); // Expect score to increment by 1
    }

    [Test]
    public void evaluateAnswer_DoesNotIncrementScore_WhenIncorrect()
    {
        var quizManager = new GameObject().AddComponent<QuizManager>();
        quizManager.quizData = new QuizData
        {
            questions = new Question[]
            {
                new Question
                {
                    questionText = "1+1",
                    answers = new string[] { "1", "2", "3", "4", "5", "6" },
                    correctAnswerIndex = 1
                }
            }
        };
        quizManager.loadAnswers(quizManager.quizData);
        quizManager.evaluateAnswer(3);

        Assert.AreEqual(0, quizManager.getUserScore()); // Expect score to not change
    }

}