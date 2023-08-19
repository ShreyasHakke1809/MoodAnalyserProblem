using MoodAnalyzerProject;

namespace MoodAnalyzerMSTesting
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyzerFactory factory;
        [TestInitialize]
        public void Setup()
        {
            factory = new MoodAnalyzerFactory();
        }
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
        //TC 5.1
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("I am in Happy mood")]
        [DataRow("I am in Sad mood")]
        [DataRow("I am in any mood")]
        public void GivenMessageReturnParameterizedConstructor(string message)
        {
            MoodAnalyzer expected = new MoodAnalyzer(message);
            object obj = null;
            try
            {
                obj = factory.CreateMoodMoodAnalyserParameterObject("MoodAnalyzer", "MoodAnalyzer", message);
            }
            catch (MoodAnalyzerException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
            obj.Equals(expected);
        }
        //TC 5.2
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("Company", "I am in Happy mood", "Could not find class")]
        [DataRow("Student", "I am in Sad mood", "Could not find class")]
        public void GivenMessageReturnParameterizedClassNotFound(string className, string message, string expextedError)
        {
            MoodAnalyzer expected = new MoodAnalyzer(message);
            object obj = null;
            try
            {
                obj = factory.CreateMoodMoodAnalyserParameterObject(className, "MoodAnalyzer", message);

            }
            catch (MoodAnalyzerException actual)
            {
                Assert.AreEqual(expextedError, actual.Message);
            }
        }

        //TC 5.3 
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("Customer", "I am in Happy mood", "Could not find constructor")]
        [DataRow("Student", "I am in Sad mood", "Could not find constructor")]
        public void GivenMessageReturnParameterizedConstructorNotFound(string constructor, string message, string expextedError)
        {
            MoodAnalyzer expected = new MoodAnalyzer(message);
            object obj = null;
            try
            {
                obj = factory.CreateMoodMoodAnalyserParameterObject("MoodAnalyzer", constructor, message);

            }
            catch (MoodAnalyzerException actual)
            {
                Assert.AreEqual(expextedError, actual.Message);
            }
        }
    }
}