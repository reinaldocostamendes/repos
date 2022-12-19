using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Livraria.Models
{
    public class Autores
    {
        [Key]
        public int IDAutor { get; set; }
        public string Nome { get; set; }
        public string PaisOrigem { get; set; }
        public Boolean PremioNobel{ get; set; }
        public string ResumoObra { get; set; }
        public string foto { get; set; }
       // public ICollection<AutoresLivros> AutoresLivros { get; set; }
    }
}
