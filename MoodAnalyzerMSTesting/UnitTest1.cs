using MoodAnalyzerProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoodAnalyzerMSTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Sad")]
        public void GivenSadMoodReturnSad()
        {
            string expected = "Sad";
            string massage = "I am Sad";

            MoodAnalyze moodAnalyze = new MoodAnalyze(massage);

            string actual = moodAnalyze.AnalyzeMood();

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        [TestCategory("Happy")]
        [DataRow(null)]
        public void GivenHappyMoodReturnHappy(string massage)
        {
            string expected = "Happy";
           // string massage = "I am Happy";

            MoodAnalyze moodAnalyze = new MoodAnalyze(massage);

            string actual = moodAnalyze.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
    }
}
