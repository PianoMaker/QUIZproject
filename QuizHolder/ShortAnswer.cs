using System.Runtime.Serialization;


namespace QuizHolder
{
    [DataContract]
    public class ShortAnswer
    {
        [DataMember]
        public Subject Subject { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int Questionid { get; set; }

        [DataMember] 
        public int StudentAnswer { get; set; }

        public ShortAnswer(Subject subj, string email, int questionid, int answer)
        {
            Subject = subj;
            Email = email;
            Questionid = questionid;
            StudentAnswer = answer;
        }
    }
}
