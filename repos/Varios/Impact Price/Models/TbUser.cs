using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impact_Price.Models
{
    public partial class TbUser
    {
        public TbUser()
        {
            TbCategoria = new HashSet<TbCategorium>();
            TbCidades = new HashSet<TbCidade>();
            TbProdutos = new HashSet<TbProduto>();
            TbServicos = new HashSet<TbServico>();
            TbTipoServicos = new HashSet<TbTipoServico>();
        }

        public long IdUser { get; set; }
        [Column("NomeUser")]
        [Display(Name = "Nome")]
        public string NomeUser { get; set; } = null!;
        [Column("EmailUser")]
        [Display(Name = "Email")]
        public string EmailUser { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        [Column("Latsupdate")]
        [Display(Name = "Ultima atualização")]
        public DateTime? Latsupdate { get; set; }

        public virtual ICollection<TbCategorium> TbCategoria { get; set; }
        public virtual ICollection<TbCidade> TbCidades { get; set; }
        public virtual ICollection<TbProduto> TbProdutos { get; set; }
        public virtual ICollection<TbServico> TbServicos { get; set; }
        public virtual ICollection<TbTipoServico> TbTipoServicos { get; set; }
    }
}
