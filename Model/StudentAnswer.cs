using System.Runtime.Serialization;
using Models;

namespace Utilities;

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
        T_mark = st.T_mark;
        Mh_quiz = q;
    }

    public StudentAnswer(Student st, SQuiz q)
    {
        Name = st.Name;
        SurName = st.SurName;
        Email = st.Email;
        Password = st.Password;
        S_mark = st.S_mark;
        T_mark = st.T_mark;
        S_quiz = q;
    }

}
