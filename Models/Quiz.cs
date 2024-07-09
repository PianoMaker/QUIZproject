using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Quiz
    {
        private string question;

        private List<string> answers;

        private int correctanswer;

        private int? studentanswer;
        public Quiz() { }

        public Quiz(string question, string answer1, string answer2, string answer3, string answer4, int correctanswer)
        {
            Question = question;
            Answers = new List<string>()
            { answer1, answer2, answer3, answer4};
            this.correctanswer = correctanswer;
        }

        public string Question { get => question; set => question = value; }
        public List<string> Answers { get => answers; set => answers = value; }

        public bool IfCorrect()
        {
            return studentanswer == correctanswer;
        }

    }
}
