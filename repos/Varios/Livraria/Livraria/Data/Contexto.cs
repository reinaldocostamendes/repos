using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Livraria.Models
{
    public class Contexto:DbContext
    {
        public DbSet<Autores> Autors { get; set; }
    }
}
