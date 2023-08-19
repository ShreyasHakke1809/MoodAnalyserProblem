namespace MoodAnalyzerProject
{
    public class MoodAnalyzer
    {
        public string message;
        public MoodAnalyzer()
        {
            Console.WriteLine("Default Constructor");
        }
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(null))
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionTypes.NULL_MOOD_EXCEPTION, "Message should not be null");
                }
                else if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionTypes.EMPTY_MOOD_EXCEPTION, "Message should not be empty");
                }
                else if (this.message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (MoodAnalyzerException)
            {
                return "HAPPY";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "HAPPY";
            }
        }
    }
}

