using System;
using System.Collections.Generic;

namespace Impact_Price.Models
{
    public partial class TbCategorium
    {
        public TbCategorium()
        {
            TbProdutos = new HashSet<TbProduto>();
        }

        public long IdCategoria { get; set; }
        public string NomeCategoria { get; set; } = null!;
        public string? DescricaoCategoria { get; set; }
        public long? IdUser { get; set; }
        public DateTime? Lastupdate { get; set; }

        public virtual TbUser? IdUserNavigation { get; set; }
        public virtual ICollection<TbProduto> TbProdutos { get; set; }
    }
}
