using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMaryTech.Models;
using ApiMaryTech.Context;
using Microsoft.AspNetCore.Mvc;

namespace ApiMaryTech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly ApiMaryTechContext _context; 

        public ProdutoController (ILogger<ProdutoController> logger, ApiMaryTechContext context)
        {
            _logger = logger;
            _context = context;
        }

    [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produto.ToList();
            if(produtos is null)
                return NotFound();
            
            return produtos;
        }

        [HttpGet("{id:int}", Name ="GetProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produtos = _context.Produto.FirstOrDefault(p => p.Id == id);
            if(produtos is null)
                return NotFound("Produto não encontrado");
            
            return disciplina;
        }

        
        [HttpPost]
        public ActionResult Post(Disciplina disciplinas){
            _context.Disciplinas.Add(disciplinas);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetDisciplinas",
                new{id = disciplinas.Id},
                disciplinas);
                
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Disciplina disciplina){
            if(id != disciplina.Id)
                return BadRequest();

            _context.Entry(disciplina).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(disciplina);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var disciplina = _context.Disciplinas.FirstOrDefault(p => p.Id == id);
            
            if(disciplina is null) 
                return NotFound();

            _context.Disciplinas.Remove(disciplina);
            _context.SaveChanges();

            return Ok(disciplina);
        }

    }
}