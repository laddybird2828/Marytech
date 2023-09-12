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
    public class ClienteController : ControllerBase
    {
        [HttpGet(Name = "clientes")]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

        
            clientes.Add(new Cliente
            {   Id = 22,
                Nome = "Taylor Swift",
                NumeroWhatsapp = "5511999999999"
            });

            clientes.Add(new Cliente
            {   Id = 666,
                Nome = "Jhon Lennon",
                NumeroWhatsapp = "5511888888888"
            });

            return clientes;
        }
    }
}