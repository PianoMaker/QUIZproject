using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    [Table("Students")]
    public class Student
    {


        [Column("id")]
        [DataMember]
        public int Id { get; set; }

        
        [Column("e-mail")]
        [MaxLength(100)]
        [DataMember]
        public string Email { get; set; } = null!;

        [Column("Password")]
        [MaxLength(100)]
        [DataMember]
        public string Password { get; set; } = null!;

        [Column("Name")]
        [MaxLength(100)]
        [DataMember]
        public string Name { get; set; } = null!;

        [Column("SurName")]
        [MaxLength(100)]
        [DataMember]
        public string SurName { get; set; } = null!;

        [Column("MusicHistory_question_answered")]
        [DataMember]
        public int T_answered { get; set; }

        [Column("MusicHistory_correct_answers")]
        [DataMember]
        public int T_correctAnswers { get; set; }

        [Column("MusicHistory_mark")]        
        [DataMember]
        public int? T_mark { get; set; }

        [Column("Solfegio_answered")]
        [DataMember]
        public int S_answered { get; set; }

        [Column("Solfegio_correct_answers")]
        [DataMember]
        public int S_correctAnswers { get; set; }

        [Column("Solfegio_mark")]
        [DataMember]
        public int? S_mark { get; set; } 

    }
}
