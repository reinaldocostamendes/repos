using System;
using System.Collections.Generic;

namespace Impact_Price.Models
{
    public partial class TbTipoServico
    {
        public long IdTipo { get; set; }
        public string NomeTipo { get; set; } = null!;
        public long IdUser { get; set; }
        public DateTime? Lastupdate { get; set; }

        public virtual TbUser IdUserNavigation { get; set; } = null!;
    }
}
