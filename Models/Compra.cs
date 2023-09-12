using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMaryTech.Models
{
    
        public class Compra
    {
        
        public int Id { get; set; }
        
        public string ClienteNome { get; set; }

        public string ProdutoDescricao { get; set; }

        public decimal ProdutoValor  { get; set; }
        
    }
}
