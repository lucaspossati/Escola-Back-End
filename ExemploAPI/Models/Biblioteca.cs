using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExemploAPI.Models
{
    public class Biblioteca
    {
        [Key()]
        public int Id { get; set;  }
        [ForeignKey("Aluno")]
        public int AlunoId { get; set; }
        public virtual Alunos Aluno { get; set; }

        public string NomeLivro { get; set; }

        public DateTime? AnoLancamento { get; set; }

        public string Genero { get; set; }

        public int RA { get; set; }

        
    }
}