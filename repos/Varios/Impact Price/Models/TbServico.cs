using System;
using System.Collections.Generic;

namespace Impact_Price.Models
{
    public partial class TbServico
    {
        public TbServico()
        {
            TbPedidos = new HashSet<TbPedido>();
        }

        public long IdServico { get; set; }
        public string NomeServico { get; set; } = null!;
        public string? DescricaoServico { get; set; }
        public string? MoradaServico { get; set; }
        public string? CodigoPostalServico { get; set; }
        public string? LocalidadeServico { get; set; }
        public string? NifServico { get; set; }
        public long? IdCidade { get; set; }
        public long? IdUser { get; set; }
        public DateTime? Lastupdate { get; set; }

        public virtual TbCidade? IdCidadeNavigation { get; set; }
        public virtual TbUser? IdUserNavigation { get; set; }
        public virtual ICollection<TbPedido> TbPedidos { get; set; }
    }
}
