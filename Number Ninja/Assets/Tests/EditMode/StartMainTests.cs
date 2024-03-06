using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StartMainTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void OnInputChange_UpdatesUserName()
    {
        var startMain = new GameObject().AddComponent<StartMain>();
        startMain.OnInputChange("TestUser");
        Assert.AreEqual("TestUser", StartMain.getUserName());
    }
}

