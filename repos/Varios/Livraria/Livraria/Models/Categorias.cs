using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Categorias
    {
        [Key]
        public int IDCategoria { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
       // public ICollection<Livros> Livros { get; set; }
    }
}
