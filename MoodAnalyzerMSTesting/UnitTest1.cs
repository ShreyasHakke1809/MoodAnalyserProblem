using System;
using MoodAnalyzerProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoodAnalyzerMSTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Sad")]
        public void TestSadMood()
        {
            //Arrange
            string message = "I am in sad Mood";
            string expected = "SAD";
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

            //Act
            string actual = moodAnalyzer.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [TestCategory("Happy")]
        public void TestHappyMood() 
        {
            //Arrange
            string message = "I am in Happy Mood";
            string expected = "Happy";
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

            //Act
            string actual = moodAnalyzer.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
