using Microsoft.EntityFrameworkCore;
using RegistroUsuario.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuario.DAL
{
    public class Contexto:DbContext
    {
        public DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\TeacherControl.db");

        }
    }
}
