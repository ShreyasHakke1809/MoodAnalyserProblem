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
        public object CreateMoodMoodAnalyserParameterObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyzer);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                else
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND, "Could not find constructor");
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionTypes.CLASS_NOT_FOUND, "Could not find class");
            }
        }
    }
}
