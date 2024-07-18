using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class StudentLogin : Student
    {
        [DataMember]
        public bool Ifnew { get; set; }

        public StudentLogin() { }
        public StudentLogin(Student student, bool ifnew)  
        {
            Ifnew = ifnew;            
            Name = student.Name;
            SurName = student.SurName;
            Email = student.Email;
            Password = student.Password;
            T_mark = student.T_mark;
            S_mark = student.S_mark;
        }
    }
}
