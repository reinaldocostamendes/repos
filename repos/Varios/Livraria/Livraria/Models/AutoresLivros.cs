using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class AutoresLivros
    {
        [Key]
        public int IDAutorLivro { get; set; }
        [ForeignKey("Autores")]
        public int Autor { get; set; }
        [ForeignKey("Livros")]
        public int Livro { get; set; }
    }
}
