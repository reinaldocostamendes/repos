using System;
using System.Collections.Generic;

namespace Impact_Price.Models
{
    public partial class TbPedido
    {
        public long IdPedido { get; set; }
        public long IdCliente { get; set; }
        public long IdServico { get; set; }
        public DateTime? Lastupdate { get; set; }

        public virtual TbCliente IdClienteNavigation { get; set; } = null!;
        public virtual TbServico IdServicoNavigation { get; set; } = null!;
    }
}
