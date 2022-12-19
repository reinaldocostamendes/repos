using System;
using System.Collections.Generic;

namespace Impact_Price.Models
{
    public partial class TbCidade
    {
        public TbCidade()
        {
            TbServicos = new HashSet<TbServico>();
        }

        public long IdCidade { get; set; }
        public string NomeCidade { get; set; } = null!;
        public string? DescricaoCidade { get; set; }
        public long IdUser { get; set; }
        public DateTime? Lastupdate { get; set; }

        public virtual TbUser IdUserNavigation { get; set; } = null!;
        public virtual ICollection<TbServico> TbServicos { get; set; }
    }
}
