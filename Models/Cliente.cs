using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMaryTech.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumeroWhatsapp { get; set; }

        // adicionando uma lista de compras associadas ao cliente
        // nós amamos o doutor eliezio!
        //public List<Compra> Compras { get; set; }
    }
}