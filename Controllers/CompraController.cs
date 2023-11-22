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
    public class CompraController : ControllerBase
    {
        private readonly ILogger<CompraController> _logger;
        private readonly ApiMaryTechContext _context;
        public CompraController(ILogger<CompraController> logger, ApiMaryTechContext context)
        {
            _logger = logger;
            _context = context;
        }
        
    [HttpGet]
    public ActionResult<IEnumerable<Compra>> Get()
    {
        var compras = _context.Compras.Include(c => c.Cliente).Include(c => c.Produto).ToList();
        if (compras.Count == 0)
            return NotFound();

        return compras;
    }

    [HttpPost]
    public ActionResult Post(Compra compra)
    {
        _context.Compras.Add(compra);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetCompra", new { id = compra.Id }, compra);
    }

    [HttpGet("{id:int}", Name = "GetCompra")]
    public ActionResult<Compra> Get(int id)
    {
        var compra = _context.Compras.Include(c => c.Cliente).Include(c => c.Produto).FirstOrDefault(p => p.Id == id);
        if (compra is null)
            return NotFound("Compra não encontrada.");

        return compra;
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Compra compra)
    {
        if (id != compra.Id)
            return BadRequest();

        _context.Entry(compra).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(compra);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var compra = _context.Compras.FirstOrDefault(p => p.Id == id);

        if (compra is null)
            return NotFound();

        _context.Compras.Remove(compra);
        _context.SaveChanges();

        return Ok(compra);
    }
}
}  