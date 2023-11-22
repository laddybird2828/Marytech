using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMaryTech.Models
{
    public class Compra
    {
        public int Id { get; set; }
        
        // Substituir a string ClienteNome por uma referência à classe Cliente
        //eliezio é lindo!
        public Cliente Cliente { get; set; }

        // Substituir a string ProdutoDescricao por uma referência à classe Produto
        //eliezio é lindo!
        public Produto Produto { get; set; }

        public decimal ProdutoValor { get; set; }

        public decimal ValorTotal
        {
            get { return ProdutoValor * 1.1m; } 
        }

    }
}
