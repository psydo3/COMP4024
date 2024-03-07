using NUnit.Framework;
using UnityEngine;

public class DisplayUserFeedbackTests
{
    private DisplayUserFeedback feedbackScript;

    [SetUp]
    public void SetUp()
    {
        feedbackScript = new GameObject().AddComponent<DisplayUserFeedback>();
        feedbackScript.setTotalNumQuestions(5);
    }

    [Test]
    public void ShowNextFeedbackOnClick_IncreasesQuestionNumber()
    {
        feedbackScript.setQuestionNumber(0);
        feedbackScript.showNextFeedbackOnClick();
        Assert.AreEqual(1, feedbackScript.getQuestionNumber(), "Question number should increase by 1 after calling showNextFeedbackOnClick.");
    }

    [Test]
    public void ShowNextFeedbackOnClick_DoesNotExceedTotalQuestions()
    {
        feedbackScript.setQuestionNumber(0);
        feedbackScript.setTotalNumQuestions(1);
        feedbackScript.showNextFeedbackOnClick();
        Assert.AreEqual(0, feedbackScript.getQuestionNumber(), "Question number should not exceed total number of questions.");
    }

    [Test]
    public void ShowPrevFeedbackOnClick_DecreasesQuestionNumber()
    {
        feedbackScript.setQuestionNumber(2);
        feedbackScript.setTotalNumQuestions(3);
        feedbackScript.showPrevFeedbackOnClick();
        Assert.AreEqual(1, feedbackScript.getQuestionNumber(), "Question number should decrease by 1 after calling showPrevFeedbackOnClick.");
    }

    [Test]
    public void ShowPrevFeedbackOnClick_DoesNotGoBelowZero()
    {
        feedbackScript.setQuestionNumber(0);
        feedbackScript.showPrevFeedbackOnClick();
        Assert.AreEqual(0, feedbackScript.getQuestionNumber(), "Question number should not decrease below 0.");
    }
}
