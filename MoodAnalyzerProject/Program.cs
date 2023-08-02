using System.Threading.Channels;

namespace MoodAnalyzerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyzer Program");
            MoodAnalyze mood = new MoodAnalyze("I am Happy");
            Console.WriteLine("Mood is "+mood.AnalyzeMood());
        }
    }
}