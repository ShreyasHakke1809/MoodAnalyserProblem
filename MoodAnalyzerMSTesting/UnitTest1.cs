using System;
using MoodAnalyzerProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoodAnalyzerMSTesting
{
    [TestClass]
    public class UnitTest1
    {
        //TC1.1
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
        //TC1.2
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
        //TC 2.1
        [TestMethod]
        [TestCategory("Null Exception")]
        public void GivenNullMessageReturnHappyMood()
        {
            //Arrange
            string message = null;
            string expected = "HAPPY";
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

            //Act
            string actual = moodAnalyzer.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        //TC 3.1 
        [TestMethod]
        [TestCategory("Custom Exception")]
        [DataRow(null, "Message should not be null")]
        [DataRow("", "Message should not be empty")]
        public void GivenNullMessageTestCustomException(string userInput, string expected)
        {
            //Arrange
            //string message = null;
            //string expected = "HAPPY";
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(userInput);
            try
            {
                //Act
                string actual = moodAnalyzer.AnalyseMood();
            }
            catch (MoodAnalyzerException ex)
            {
                //Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }
}
