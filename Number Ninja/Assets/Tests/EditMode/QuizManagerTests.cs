using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class QuizManagerTests
{
    private QuizManager quizManager;
    Question mockQuestion1 = new Question { questionText = "1+1?", answers = new string[] { "99", "2", "31" }, correctAnswerIndex = 1 };

    [SetUp]
    public void SetUp()
    {
        // Initialize QuizManager
        quizManager = new GameObject().AddComponent<QuizManager>();

        var mockQuestion2 = new Question { questionText = "2+1?", answers = new string[] { "100", "22", "3" }, correctAnswerIndex = 2 };
        var mockQuizData = new QuizData
        {
            questions = new Question[]
            {   mockQuestion1,
                mockQuestion2  
            }
        };

        quizManager.setQuizData(mockQuizData);
        QuizManager.userScore = 0;
    }

    [Test]
    public void EvaluateAnswer_DoesNotIncreaseScore_WhenIncorrect()
    {
        quizManager.loadAnswers(qNum:0);
        quizManager.evaluateAnswer(question:mockQuestion1, chosenAnswer:999, chosenAnswerIndex:-1);
        Assert.AreEqual(0, QuizManager.getUserScore());
    }

    [Test]
    public void LoadNextQuestionOnClick_LoadsNextQuestion_WhenCalled()
    {
        quizManager.loadNextQuestionOnClick(clickedBubbleIndex:0); // Simulate clicking the first answer
        Assert.AreEqual(1, quizManager.getQuestionNumber()); // Verify that questionNumber is incremented
    }
}
