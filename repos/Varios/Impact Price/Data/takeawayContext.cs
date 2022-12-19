using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Impact_Price.Models;

namespace Impact_Price.Data
{
    public partial class takeawayContext : DbContext
    {
        public takeawayContext()
        {
        }

        public takeawayContext(DbContextOptions<takeawayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCategorium> TbCategoria { get; set; } = null!;
        public virtual DbSet<TbCidade> TbCidades { get; set; } = null!;
        public virtual DbSet<TbCliente> TbClientes { get; set; } = null!;
        public virtual DbSet<TbPedido> TbPedidos { get; set; } = null!;
        public virtual DbSet<TbPedidoProduto> TbPedidoProdutos { get; set; } = null!;
        public virtual DbSet<TbProduto> TbProdutos { get; set; } = null!;
        public virtual DbSet<TbProdutoServico> TbProdutoServicos { get; set; } = null!;
        public virtual DbSet<TbServico> TbServicos { get; set; } = null!;
        public virtual DbSet<TbTipoServico> TbTipoServicos { get; set; } = null!;
        public virtual DbSet<TbUser> TbUsers{ get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=takeaway;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCategorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK_Categoria");

                entity.ToTable("Tb_Categoria");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.DescricaoCategoria)
                    .HasColumnType("ntext")
                    .HasColumnName("descricao_categoria");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Lastupdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.NomeCategoria)
                    .HasMaxLength(250)
                    .HasColumnName("nome_categoria");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TbCategoria)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_CategoriaIdUser");
            });

            modelBuilder.Entity<TbCidade>(entity =>
            {
                entity.HasKey(e => e.IdCidade)
                    .HasName("PK_Cidade");

                entity.ToTable("Tb_Cidade");

                entity.Property(e => e.IdCidade).HasColumnName("id_cidade");

                entity.Property(e => e.DescricaoCidade)
                    .HasColumnType("ntext")
                    .HasColumnName("descricao_cidade");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Lastupdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.NomeCidade)
                    .HasMaxLength(250)
                    .HasColumnName("nome_cidade");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TbCidades)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CidadeIdUser");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK_Cliente");

                entity.ToTable("Tb_Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(20)
                    .HasColumnName("codigo_postal");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("data_nascimento");

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(250)
                    .HasColumnName("email_cliente");

                entity.Property(e => e.Lastupdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Loaclidade)
                    .HasMaxLength(250)
                    .HasColumnName("loaclidade");

                entity.Property(e => e.Login)
                    .HasMaxLength(250)
                    .HasColumnName("login");

                entity.Property(e => e.Morada)
                    .HasMaxLength(500)
                    .HasColumnName("morada");

                entity.Property(e => e.Nif)
                    .HasMaxLength(20)
                    .HasColumnName("nif");

                entity.Property(e => e.NomeCliente)
                    .HasMaxLength(250)
                    .HasColumnName("nome_cliente");

                entity.Property(e => e.Senha)
                    .HasMaxLength(250)
                    .HasColumnName("senha");
            });

            modelBuilder.Entity<TbPedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK_Pedido");

                entity.ToTable("Tb_Pedido");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdServico).HasColumnName("id_servico");

                entity.Property(e => e.Lastupdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbPedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Cliente");

                entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany(p => p.TbPedidos)
                    .HasForeignKey(d => d.IdServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Servico");
            });

            modelBuilder.Entity<TbPedidoProduto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tb_Pedido_produto");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("quantidade");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Produto_pedio");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PEdido_Produto_produto");
            });

            modelBuilder.Entity<TbProduto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK_Produto");

                entity.ToTable("Tb_Produto");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.Property(e => e.DescricaoProduto)
                    .HasColumnType("ntext")
                    .HasColumnName("descricao_produto");

                entity.Property(e => e.Foto)
                    .HasColumnType("image")
                    .HasColumnName("foto");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Lastupdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.NomeProduto)
                    .HasMaxLength(250)
                    .HasColumnName("nome_produto");

                entity.Property(e => e.Preco)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("preco");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("quantidade");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.TbProdutos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produto_Categoria");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TbProdutos)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdutoIdUser");
            });

            modelBuilder.Entity<TbProdutoServico>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tb_Produto_Servico");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.Property(e => e.IdServico).HasColumnName("id_servico");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produto_Servico_Produto");

                entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produto_Servico_Servico");
            });

            modelBuilder.Entity<TbServico>(entity =>
            {
                entity.HasKey(e => e.IdServico)
                    .HasName("PK_Servico");

                entity.ToTable("Tb_Servico");

                entity.Property(e => e.IdServico).HasColumnName("id_servico");

                entity.Property(e => e.CodigoPostalServico)
                    .HasMaxLength(20)
                    .HasColumnName("codigo_postal_servico");

                entity.Property(e => e.DescricaoServico)
                    .HasColumnType("ntext")
                    .HasColumnName("descricao_servico");

                entity.Property(e => e.IdCidade).HasColumnName("id_cidade");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Lastupdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.LocalidadeServico)
                    .HasMaxLength(250)
                    .HasColumnName("localidade_servico");

                entity.Property(e => e.MoradaServico)
                    .HasMaxLength(250)
                    .HasColumnName("morada_servico");

                entity.Property(e => e.NifServico)
                    .HasMaxLength(20)
                    .HasColumnName("nif_servico");

                entity.Property(e => e.NomeServico)
                    .HasMaxLength(250)
                    .HasColumnName("nome_servico");

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.TbServicos)
                    .HasForeignKey(d => d.IdCidade)
                    .HasConstraintName("FK_ServicoCidade");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TbServicos)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_ServicoIdUser");
            });

            modelBuilder.Entity<TbTipoServico>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK_TipoServico");

                entity.ToTable("Tb_TipoServico");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Lastupdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.NomeTipo)
                    .HasMaxLength(250)
                    .HasColumnName("nome_tipo");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TbTipoServicos)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdUser");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_User");

                entity.ToTable("Tb_User");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.EmailUser)
                    .HasMaxLength(250)
                    .HasColumnName("email_user");

                entity.Property(e => e.Latsupdate)
                    .HasColumnType("datetime")
                    .HasColumnName("latsupdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Login)
                    .HasMaxLength(250)
                    .HasColumnName("login");

                entity.Property(e => e.NomeUser)
                    .HasMaxLength(250)
                    .HasColumnName("nome_user");

                entity.Property(e => e.Senha)
                    .HasMaxLength(250)
                    .HasColumnName("senha");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
