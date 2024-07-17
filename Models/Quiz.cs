﻿namespace Models
{
    
    public class Quiz
    {
        private string question;

        private List<string> answers;

        public int Correctanswer { get; set; }

        public int? Studentanswer { get; set; }

        
        public Quiz() { }

        public Quiz(string question, List<string> answers, int correctanswer)
        {
            Question = question;
            Answers = answers;
            Correctanswer = correctanswer;
        }

        public string Question { get => question; set => question = value; }
        public List<string> Answers { get => answers; set => answers = value; }        

        public bool IfCorrect()
        {
            return Studentanswer == Correctanswer;
        }

    }
}
