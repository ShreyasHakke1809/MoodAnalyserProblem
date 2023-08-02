using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProject
{
    public class MoodAnalyze
    {
        public string massage;
        public MoodAnalyze(string massage) 
        {
            this.massage = massage;
        }
        public string AnalyzeMood()
        {
            try
            {
                if (this.massage.Contains("Sad"))
                {
                    return "Sad";
                }
                else
                {
                    return "Happy";
                }
            }
            catch
            {
                return "Happy";
            }
            
        }
    }
}
