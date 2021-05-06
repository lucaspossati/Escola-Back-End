using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ExemploAPI.Models;

namespace ExemploAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/disciplinas")]
    public class DisciplinasController : ApiController
    {
        private static List<Disciplinas> disciplinas = new List<Disciplinas>();

        private BaseContext _context = new BaseContext();


        public List<Disciplinas> Get()
        {
            return _context.Disciplina.ToList();
        }

        [Route("getDisciplinasbyID/{id}")]
        [HttpGet]
        public Disciplinas getDisciplinasbyID(int id)
        {
            Disciplinas disciplina = _context.Disciplina.Where(x => x.Id == id).FirstOrDefault();

            return disciplina;
        }

        [Route("disciplinas")]
        [Authorize]
        [HttpPost]
        public String AlteraDisciplinas(Disciplinas disciplina)
        {

            var original = _context.Disciplina.Where(x => x.Id == disciplina.Id).FirstOrDefault();

            if (original != null)
            {
                _context.Entry(original).CurrentValues.SetValues(disciplina);
            }
            else
            {
                _context.Disciplina.Add(disciplina);
            }


            try
            {
                _context.SaveChanges();
                return "Salvo com sucesso";
            }
            catch
            {
                return "Erro ao salvar a disciplina";
            }

        }

        [Route("deletarDisciplina/{id}")]
        [HttpDelete]
        [Authorize]
        public void Delete(int id)
        {         

            var itemToRemove = _context.Disciplina.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                _context.Disciplina.Remove(itemToRemove);
                _context.SaveChanges();
            }
        }
    }
}
