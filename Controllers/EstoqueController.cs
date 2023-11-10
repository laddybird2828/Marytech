using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ApiMaryTech.Context;
using ApiMaryTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMaryTech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly ILogger<EstoqueController> _logger;
        private readonly ApiMaryTechContext _context;

        public EstoqueController(ILogger<EstoqueController> logger, ApiMaryTechContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Estoque>> Get()
        {
            var estoques = _context.Estoques.ToList();
            if(estoques is null)
                return NotFound();
            
            return estoques;
        }

        [HttpGet("{id:int}", Name="GetEstoque")]

        public ActionResult<Estoque> Get(int id)
        {
            var estoques = _context.Estoques.FirstOrDefault(p => p.Id == id);
            if(estoques is null)
                return NotFound("Não encontrado");
            
            return estoques;
        }
 
        [HttpPost]
        public ActionResult Post(Estoque estoques){
            _context.Estoques.Add(estoques);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetEstoques", 
                new{ id = estoques.Id},
                estoques);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Estoque estoques){
            if(id != estoques.Id)
                return BadRequest();

            _context.Entry(estoques).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(estoques);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var estoques = _context.Estoques.FirstOrDefault(p => p.Id == id);
            
            if(estoques is null) 
                return NotFound();

            _context.Estoques.Remove(estoques);
            _context.SaveChanges();

            return Ok(estoques);
        }

    }   
}