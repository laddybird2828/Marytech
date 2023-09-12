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
    public class ProdutoController : ControllerBase
    {
        [HttpGet(Name = "produtos")]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            List<Produto> produtos = new List<Produto>();

            
            produtos.Add(new Produto
            {   
                Id= 2,
                Descricao = "Caneca vingadores",
                Tamanho = "15 cm",
                Peso = "10 g",
                Cor = "Personalizada",
                Valor = 30
            });

            produtos.Add(new Produto
            {
                Id = 9,
                Descricao = "Caderno do PT",
                Tamanho = "21 cm x 30 cm",
                Peso = "200 g",
                Cor = "Vermelho",
                Valor = 50
            });

            return produtos;
    }
  }
}