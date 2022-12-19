using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Livraria.Models;

namespace Livraria.Data
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext (DbContextOptions<LivrariaContext> options)
            : base(options)
        {
        }

        public DbSet<Livraria.Models.Autores> Autores { get; set; }

        public DbSet<Livraria.Models.Categorias> Categorias { get; set; }

        public DbSet<Livraria.Models.Livros> Livros { get; set; }

        public DbSet<Livraria.Models.Clientes> Clientes { get; set; }

        public DbSet<Livraria.Models.Encomendas> Encomendas { get; set; }

        public DbSet<Livraria.Models.AutoresLivros> AutoresLivros { get; set; }

        public DbSet<Livraria.Models.EncomendaLivros> EncomendaLivros { get; set; }
    }
}
