using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Encomendas
    {
        [Key]
        public int IDEncomenda { get; set; }
        public string Data { get; set; }
        [ForeignKey("Clientes")]
        public string NIFCliente { get; set; }
      //  public ICollection<EncomendaLivros> EncomendaLivros { get; set; }
    }
}
