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
            var produtos = _context.Produtos.ToList();
            if(produtos is null)
                return NotFound();
            
            return produtos;
        }

        [HttpGet("{id:int}", Name ="GetProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produtos = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if(produtos is null)
                return NotFound("Produto não encontrado");
            
            return produtos;
        }

        
        [HttpPost]
        public ActionResult Post(Produto produtos){
            _context.Produtos.Add(produtos);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetProduto",
                new{id = produtos.Id},
                produtos);
                
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produtos){
            if(id != produtos.Id)
                return BadRequest();

            _context.Entry(produtos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(produtos);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var produtos = _context.Produtos.FirstOrDefault(p => p.Id == id);
            
            if(produtos is null) 
                return NotFound();

            _context.Produtos.Remove(produtos);
            _context.SaveChanges();

            return Ok(produtos);
        }

    }
}