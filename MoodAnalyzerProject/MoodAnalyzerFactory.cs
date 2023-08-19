using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProject
{
    public class MoodAnalyzerFactory
    {
        public object CreateMoodMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyzerType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyzerType);
                }
                catch (ArgumentNullException)
                {

                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionTypes.CLASS_NOT_FOUND, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
            }
        }
    }
}
