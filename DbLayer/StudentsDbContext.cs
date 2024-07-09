using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DbLayer
{
    public class StudentsDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options) 
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

        }

        public void Create()
        {
            Database.EnsureCreated();
        }

        public void Delete()
        {
            Database.EnsureDeleted();
        }

        public StudentsDbContext()
        { }

    }
}
