using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
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
