using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Students")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("e-mail")]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [Column("Name")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Column("SurName")]
        [MaxLength(100)]
        public string SurName { get; set; } = null!;

        [Column("MusicHistory_mark")]
        [MaxLength(100)]
        public int MH_mark { get; set; } 

        [Column("Solfegio_mark")]        
        public int S_mark { get; set; } 


    }
}
