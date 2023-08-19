using MoodAnalyzerProject;

namespace TestProject1
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
        //TC 4.1 
        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyzerProblem.Reflection.Customer", "Customer")]
        public void GivenMoodAnalyzerClassName_ReturnMoodAnalyzerObject(string className, string constructorName)
        {
            MoodAnalyzer expected = new MoodAnalyzer();
            object obj = null;

            MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
            obj = factory.CreateMoodMoodAnalyse(className, constructorName);
            expected.Equals(obj);
        }

        //TC 4.2 
        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyzerProblem.Reflection.Owner", "Reflection.Owner", "Class not found")]
        public void GivenImproperClassName_ThrowException(string className, string constructorName, string expected)
        {
            try
            {
                MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
                object actual = factory.CreateMoodMoodAnalyse(className, constructorName);
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        //TC 4.3 
        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyzerProblem.Reflection.Customer", "Reflection.OwnerMood", "Constructor not found")]
        public void GivenImproperConstructorName_ThrowException(string className, string constructorName, string expected)
        {
            try
            {
                MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
                object actual = factory.CreateMoodMoodAnalyse(className, constructorName);
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}
