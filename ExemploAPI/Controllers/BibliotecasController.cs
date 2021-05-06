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
    [RoutePrefix("api/biblioteca")]
    public class BibliotecasController : ApiController
    {
        private static List<Biblioteca> biblioteca = new List<Biblioteca>();

        private BaseContext _context = new BaseContext();


        public List<Biblioteca> Get()
        {
            return _context.Bibliotecas.ToList();
        }

        [Route("getLivrosbyID/{id}")]
        [HttpGet]
        public Biblioteca getLivrosbyID(int id)
        {
            Biblioteca biblioteca = _context.Bibliotecas.Where(x => x.Id == id).FirstOrDefault();

            return biblioteca;
        }


        [Route("biblioteca")]
        [Authorize]
        [HttpPost]
        public String AlteraBiblioteca(Biblioteca biblioteca)
        {

            var original = _context.Bibliotecas.Where(x => x.Id == biblioteca.Id).FirstOrDefault();

            if (original != null)
            {
                _context.Entry(original).CurrentValues.SetValues(biblioteca);
            }
            else
            {
                _context.Bibliotecas.Add(biblioteca);
            }
           

            try
            {
                _context.SaveChanges();
                return "Salvo com sucesso";
            }
            catch
            {
                return "Erro ao salvar a biblioteca";
            }

        }

        [Route("deletarBiblioteca/{id}")]
        [HttpDelete]
        [Authorize]
        public void Delete(int id)
        {
            var itemToRemove = _context.Bibliotecas.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                _context.Bibliotecas.Remove(itemToRemove);
                _context.SaveChanges();
            }
        }
    }
}
