using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProject
{
    public class MoodAnalyzerException: Exception
    {
        public ExceptionTypes type;
        public enum ExceptionTypes
        {
            NULL_MOOD_EXCEPTION,
            EMPTY_MOOD_EXCEPTION
        }
        public MoodAnalyzerException(ExceptionTypes type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
