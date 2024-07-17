namespace QuizHolder
{    
    public class Quiz
    {
        private string question;

        private List<string> answers;

        public int? Studentanswer { get; set; }
 
        public Image? Picture { get; set; }
        public Quiz() { }

        public Quiz(string question, List<string> answers)
        {
            Question = question;
            Answers = answers;            
        }

        public Quiz(string question, List<string> answers, Image image)
        {
            Question = question;
            Answers = answers;            
            Picture = image;
        }

        public string Question { get => question; set => question = value; }
        public List<string> Answers { get => answers; set => answers = value; }        


    }
}
