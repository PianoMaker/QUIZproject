using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class StudentLogin : Student
    {
        [DataMember]
        public bool Ifnew { get; set; }
        public StudentLogin(Student student, bool ifnew)  
        {
            Ifnew = ifnew;            
            Name = student.Name;
            SurName = student.SurName;
            Email = student.Email;
            MH_mark = student.MH_mark;
            S_mark = student.S_mark;
        }
    }
}
