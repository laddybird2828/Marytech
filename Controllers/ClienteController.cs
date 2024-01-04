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
    [Authorize(AuthenticationSchemes ="Bearer")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/cliente")]
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


        [HttpGet("{id:int}", Name ="GetCliente")]
        public ActionResult<Cliente> Get(int id)
        {
            var clientes = _context.Clientes.FirstOrDefault(p => p.Id == id);
            if(clientes is null)
                return NotFound("Cliente não encontrado");
           
            return clientes;
        }


       
        [HttpPost]
        public ActionResult Post(Cliente clientes){
            _context.Clientes.Add(clientes);
            _context.SaveChanges();


            return new CreatedAtRouteResult("GetCliente",
                new{id = clientes.Id},
                clientes);
               
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Cliente clientes){
            if(id != clientes.Id)
                return BadRequest();


            _context.Entry(clientes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();


            return Ok(clientes);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var clientes = _context.Clientes.FirstOrDefault(p => p.Id == id);
           
            if(clientes is null)
                return NotFound();


            _context.Clientes.Remove(clientes);
            _context.SaveChanges();


            return Ok(clientes);
        }


    }
}
