namespace MoodAnalyzerProject
{
    public class MoodAnalyzerException : Exception
    {
        public ExceptionTypes type;
        public enum ExceptionTypes
        {
            NULL_MOOD_EXCEPTION,
            EMPTY_MOOD_EXCEPTION,
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND
        }
        public MoodAnalyzerException(ExceptionTypes type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
