using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator EvaluateAnswer_IncreasesScore_WhenCorrect()
    {
        quizManager.loadAnswers(0);
        yield return new WaitForSeconds(1);

        quizManager.evaluateAnswer(mockQuestion1, 2, 1);
        Assert.AreEqual(1, QuizManager.getUserScore());
    }
}
