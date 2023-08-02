using MoodAnalyzerProject;

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
        public void GivenHappyMoodReturnHappy()
        {
            string expected = "Happy";
            string massage2 = "I am Happy";

            MoodAnalyze moodAnalyze = new MoodAnalyze(massage2);

            string actual = moodAnalyze.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
    }
}
