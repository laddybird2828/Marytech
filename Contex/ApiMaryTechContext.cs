using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiMaryTech.Models;


namespace ApiMaryTech.Context
{
    
        public class ApiMaryTechContext: DbContext
    {
        public ApiMaryTechContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Compra>? Compras { get; set; }
    }
}
