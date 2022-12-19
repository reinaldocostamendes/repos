using System;
using System.Collections.Generic;

namespace Impact_Price.Models
{
    public partial class TbPedidoProduto
    {
        public long IdProduto { get; set; }
        public long IdPedido { get; set; }
        public decimal? Quantidade { get; set; }

        public virtual TbPedido IdPedidoNavigation { get; set; } = null!;
        public virtual TbProduto IdProdutoNavigation { get; set; } = null!;
    }
}
