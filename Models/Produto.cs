using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMaryTech.Models
{
    public class Produto
    {
        public int Id { get; set; }

        
        public string Descricao { get; set; }

       
        public string Tamanho { get; set; }

        
        public string Peso { get; set; }

        
        public string Cor { get; set; }

        
        public decimal Valor { get; set; }

        public int Quantidade { get; set; }

    }
}