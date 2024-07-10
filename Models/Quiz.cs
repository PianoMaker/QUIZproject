using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models   
{
    public enum Subject { Musichistory, Solfegio }
    public class Quiz
    {
        private string question;

        private List<string> answers;

        private int correctanswer;

        private int? studentanswer;
        public Quiz() { }

        public Quiz(string question, List<string> answers, int correctanswer)
        {
            Question = question;
            Answers = answers;
            Correctanswer = correctanswer;
        }

        public string Question { get => question; set => question = value; }
        public List<string> Answers { get => answers; set => answers = value; }
        public int Correctanswer { get => correctanswer; set => correctanswer = value; }

        public bool IfCorrect()
        {
            return studentanswer == Correctanswer;
        }

    }
}
