using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Livros
    {
        [Key]
        public int IDLivro { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        [ForeignKey("Categorias")]
        public int Categoria { get; set; }
        public int AnoLancamento { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeStock { get; set; }
        public string foto { get; set; }
    }
}
