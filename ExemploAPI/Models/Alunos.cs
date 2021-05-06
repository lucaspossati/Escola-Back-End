using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExemploAPI.Models
{
    public class Alunos
    {
        [Key()]
        public int Id { get; set; }
        public string Nome{ get; set; }

        public string Login { get; set; }
        public string Senha { get; set; }

        public char Sexo { get; set; }

        public DateTime? DatadeNascimento { get; set; }

        public int RA { get; set; }

        public String Curso { get; set; }

        public int Semestre { get; set; }

    }

    public class AlunoLogin
    {
        public string login { get; set; }
        public string senha { get; set; }

    }
}