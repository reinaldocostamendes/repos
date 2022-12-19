using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Clientes
    {
        [Key]
        public string NIF { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string CodigoPostal { get; set; }
        public string Localidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
       public string Codigo { get; set; }
      //  public ICollection<EncomendaLivros> EncomendaLivros { get; set; }
    }
}
