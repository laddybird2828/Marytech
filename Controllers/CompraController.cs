using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ApiMaryTech.Context;
using ApiMaryTech.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMaryTech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes ="Bearer")]
    public class CompraController : ControllerBase
    {
        private readonly ILogger<CompraController> _logger;
        private readonly ApiMaryTechContext _context;


        public CompraController (ILogger<CompraController> logger, ApiMaryTechContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Compra>> Get()
        {
            var compras = _context.Compras.ToList();
            if(compras is null)
                return NotFound();
           
            return compras;
        }


        [HttpGet("{id:int}", Name ="GetCompra")]
        public ActionResult<Compra> Get(int id)
        {
            var compras = _context.Compras.FirstOrDefault(p => p.Id == id);
            if(compras is null)
                return NotFound("Compra não encontrado");
           
            return compras;
        }


       
        [HttpPost]
        public ActionResult Post(Compra compra){
            _context.Compras.Add(compra);
            _context.SaveChanges();


            return new CreatedAtRouteResult("GetCompra",
                new{id = compra.Id},
                compra);
               
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Compra compra){
            if(id != compra.Id)
                return BadRequest();


            _context.Entry(compra).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();


            return Ok(compra);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var compras = _context.Compras.FirstOrDefault(p => p.Id == id);
           
            if(compras is null)
                return NotFound();


            _context.Compras.Remove(compras);
            _context.SaveChanges();


            return Ok(compras);
        }


    }
}
