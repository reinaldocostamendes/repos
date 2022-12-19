using System;
using System.Collections.Generic;

namespace Impact_Price.Models
{
    public partial class TbProduto
    {
        public long IdProduto { get; set; }
        public string NomeProduto { get; set; } = null!;
        public string? DescricaoProduto { get; set; }
        public decimal Preco { get; set; }
        public decimal? Quantidade { get; set; }
        public long IdCategoria { get; set; }
        public long IdUser { get; set; }
        public byte[]? Foto { get; set; }
        public DateTime? Lastupdate { get; set; }

        public virtual TbCategorium IdCategoriaNavigation { get; set; } = null!;
        public virtual TbUser IdUserNavigation { get; set; } = null!;
    }
}
