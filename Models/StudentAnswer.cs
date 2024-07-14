using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class StudentAnswer : Student
    {
        [DataMember]
        public Quiz? Mh_quiz { get; set; }
        
        [DataMember]
        public SQuiz? S_quiz { get; set; }

        public StudentAnswer(Student st, Quiz q) 
        {
            Name = st.Name;
            SurName = st.SurName;
            Email = st.Email;
            Password = st.Password;
            S_mark = st.S_mark;
            MH_mark = st.MH_mark;
            Mh_quiz = q;
        }

        public StudentAnswer(Student st, SQuiz q)
        {
            Name = st.Name;
            SurName = st.SurName;
            Email = st.Email;
            Password = st.Password;
            S_mark = st.S_mark;
            MH_mark = st.MH_mark;
            S_quiz = q;
        }

    }
}
