using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace ExemploAPI.Entity
{
    public class AlunoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public char Sexo { get; set; }

        public DateTime? DatadeNascimento { get; set; }

        public int RA { get; set; }

        public String Curso { get; set; }

        public int Semestre { get; set; }

    }
}