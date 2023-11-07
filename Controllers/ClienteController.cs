using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiMaryTechContex.Model;
using apiMaryTechContex.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiMaryTechContex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly ApiMaryTechContext _context;

        public ClienteController(ILogger<ClienteController> logger, ApiMaryTechContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
           var clientes = _context.Clientes.ToList();
           if(clientes is null)
                return NotFound();

            return clientes;
        }

        [HttpGet("{id:int}", Name="GetAluno")]
        public ActionResult<Aluno> Get(int id)
        {
           var alunos = _context.Alunos.FirstOrDefault(p => p.Id == id);
           if(alunos is null)
                return NotFound("Aluno não encontrado.");

            return alunos;
        }
 
        [HttpPost]
        public ActionResult Post(Aluno aluno){
            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetAluno", 
                new{ id = aluno.Id},
                aluno);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Aluno aluno){
            if(id != aluno.Id)
                return BadRequest();

            _context.Entry(aluno).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var aluno = _context.Alunos.FirstOrDefault(p => p.Id == id);

            if(aluno is null)
                return NotFound();

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

    }
}