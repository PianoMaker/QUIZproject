using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuizHolder
{
    public class TQuiz : Quiz
    {
        [DataMember]
        public int Correctanswer { get; set; }

        public TQuiz() { }

        public TQuiz(string question, List<string> answers, int correctanswer) :
            base(question, answers)
        {
            Question = question;
            Answers = answers;
            Correctanswer = correctanswer;
        }
        public TQuiz(string question, List<string> answers, int correctanswer, Bitmap image) :
            base(question, answers, image)
        {
            Question = question;
            Answers = answers;
            Correctanswer = correctanswer;
            Picture = image;
        }
    }
}
