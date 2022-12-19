using System;
using System.Collections.Generic;

namespace Impact_Price.Models
{
    public partial class TbProdutoServico
    {
        public long IdProduto { get; set; }
        public long IdServico { get; set; }

        public virtual TbProduto IdProdutoNavigation { get; set; } = null!;
        public virtual TbServico IdServicoNavigation { get; set; } = null!;
    }
}
