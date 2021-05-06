using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ExemploAPI.Models;
using System.Web.Http.Cors;

namespace ExemploAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/alunoss")]
    public class AlunosController : ApiController
    {
        private static List<Alunos> alunos = new List<Alunos>();

        private BaseContext _context = new BaseContext();


        [Authorize]
        public List<Alunos> Get()
        {
            return _context.Aluno.ToList();
        }

        [Route("getAlunosbyID/{id}")]
        [HttpGet]
        public Alunos getAlunosbyID(int id)
        {
            Alunos aluno = _context.Aluno.Where(x => x.Id == id).FirstOrDefault();

            return aluno;
        }

        [Route("aluno")]
        [Authorize]
        [HttpPost]
        public String AlteraAluno(Alunos aluno)
        {

            var original = _context.Aluno.Where(x => x.Id == aluno.Id).FirstOrDefault();

            if(original != null)
            {
                _context.Entry(original).CurrentValues.SetValues(aluno);
            }
            else
            {
                _context.Aluno.Add(aluno);
            }
            //alunos.Add(new Alunos(id, nome, sexo, datadenascimento, ra, curso, semestre ));

            try
            {
                _context.SaveChanges();
                return "Salvo com sucesso";
            }
            catch
            {
                return "Erro ao salvar aluno";
            }
            
        }

        [Route("login")]
        public Alunos Login(AlunoLogin login)
        {

            Alunos aluno = _context.Aluno.Where(x => x.Login == login.login && x.Senha == login.senha).FirstOrDefault();

            return aluno;

        }

        [Route("deletarAluno/{id}")]
        [HttpDelete]
        [Authorize]
        public void Delete(int id)
        {
            var itemToRemove = _context.Aluno.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                _context.Aluno.Remove(itemToRemove);
                _context.SaveChanges();
            }
            
        }


    }
}
