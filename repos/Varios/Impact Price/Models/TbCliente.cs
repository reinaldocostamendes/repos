using System;
using System.Collections.Generic;

namespace Impact_Price.Models
{
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbPedidos = new HashSet<TbPedido>();
        }

        public long IdCliente { get; set; }
        public string NomeCliente { get; set; } = null!;
        public DateTime? DataNascimento { get; set; }
        public string EmailCliente { get; set; } = null!;
        public string Nif { get; set; } = null!;
        public string? Morada { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Loaclidade { get; set; }
        public string Login { get; set; } = null!;
        public string? Senha { get; set; }
        public DateTime? Lastupdate { get; set; }

        public virtual ICollection<TbPedido> TbPedidos { get; set; }
    }
}
