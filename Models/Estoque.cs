using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMaryTech.Models
{
    
        public class Estoque
    {
        
        public int Id { get; set; }
        
        public string Quantidade { get; set; }

        public string ProdutoDescricao { get; set; }

        public decimal ProdutoValor  { get; set; }
        
    }
}