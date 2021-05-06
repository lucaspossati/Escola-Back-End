using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using ExemploAPI.Models;

namespace ExemploAPI
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("Escola") { }
        public DbSet<Alunos> Aluno { get; set; }
        public DbSet<Biblioteca> Bibliotecas { get; set; }
        public DbSet<Disciplinas> Disciplina { get; set; }

    }
}