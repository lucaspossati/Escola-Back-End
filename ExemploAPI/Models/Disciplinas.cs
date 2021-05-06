using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExemploAPI.Models
{
    public class Disciplinas
    {
        [Key()]
        public int Id { get; set; }
        public string NomeDisciplina { get; set; }

        public string NomeProfessor { get; set; }

        public string Ementa { get; set; }

        public string Curso { get; set; }

        public int Periodo { get; set; }

        


    }
}

