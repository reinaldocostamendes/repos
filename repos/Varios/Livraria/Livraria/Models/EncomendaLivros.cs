using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class EncomendaLivros
    {
        [Key]
        public int IDEncomendaLivro { get; set; }
        [ForeignKey("Encomenda")]
        public int Encomenda { get; set; }
        [ForeignKey("Livros")]
        public int Livro { get; set; }
        public int Quantidade { get; set; }
    }
}
