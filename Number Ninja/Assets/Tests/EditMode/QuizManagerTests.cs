using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class QuizManagerTests
{
    private QuizManager quizManager;

    [SetUp]
    public void SetUp()
    {
        // Initialize QuizManager
        quizManager = new GameObject().AddComponent<QuizManager>();

        var mockQuizData = new QuizData
        {
            questions = new Question[]
            {
                new Question { questionText = "1+1?", answers = new string[] {"99", "2", "31"}, correctAnswerIndex = 1 },
                new Question { questionText = "2+1?", answers = new string[] {"100", "22", "3"}, correctAnswerIndex = 2 }
            }
        };

        quizManager.setQuizData(mockQuizData);
        QuizManager.userScore = 0;
    }

    [Test]
    public void EvaluateAnswer_IncreasesScore_WhenCorrect()
    {
        quizManager.loadAnswers(0);
        quizManager.evaluateAnswer(2);
        Assert.AreEqual(1, QuizManager.getUserScore());
    }

    [Test]
    public void EvaluateAnswer_DoesNotIncreaseScore_WhenIncorrect()
    {
        quizManager.loadAnswers(0);
        quizManager.evaluateAnswer(999);
        Assert.AreEqual(0, QuizManager.getUserScore());
    }

    [Test]
    public void LoadNextQuestionOnClick_LoadsNextQuestion_WhenCalled()
    {
        quizManager.loadNextQuestionOnClick(0); // Simulate clicking the first answer
        Assert.AreEqual(1, quizManager.getQuestionNumber()); // Verify that questionNumber is incremented
    }
}
