using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

        [Column("MusicHistory_mark")]        
        [DataMember]
        public int MH_mark { get; set; } 

        [Column("Solfegio_mark")]
        [DataMember]
        public int S_mark { get; set; } 

    }
}
