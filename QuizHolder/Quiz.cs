using System.Runtime.Serialization;

namespace QuizHolder
{
    [DataContract]
    public class Quiz : ICloneable
    {
        [DataMember]
        public string Question { get; set; }

        [DataMember]
        private List<string> answers;
        
        [DataMember]
        public int? Studentanswer { get; set; }
        
        [DataMember]        
        public Bitmap Picture { get; set; }
        public Quiz() { }

        public Quiz(string question, List<string> answers)
        {
            Question = question;
            Answers = answers;            
        }

        public Quiz(string question, List<string> answers, Bitmap image)
        {
            Question = question;
            Answers = answers;            
            Picture = image;
        }

        
        public List<string> Answers { get => answers; set => answers = value; }

        public virtual object Clone()
        {
            return new Quiz
            {
                Answers = this.Answers,
                Question = this.Question,
                Picture = this.Picture,
                Studentanswer = this.Studentanswer                
            };
        }
    }
}
