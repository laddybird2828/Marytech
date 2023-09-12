using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMaryTech.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMaryTech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
        
    {
        [HttpGet(Name = "Compras")]
        public ActionResult<IEnumerable<Compra>> GetCompras()
        {
            List<Compra> compras = new List<Compra>();

            
            compras.Add(new Compra
            {
                Id= 12,
                ClienteNome = "Eliezio",
                ProdutoDescricao = "Camisa do botafogo",
                ProdutoValor = 10000
            });

            compras.Add(new Compra
            {
                Id= 13,
                ClienteNome = "Turma de MSI",
                ProdutoDescricao = "Uma foto da turma mais linda de informatica (a gente)",
                ProdutoValor = 1000000
            });

            return compras;
    }
  } 
}