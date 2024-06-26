﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Software_Lanch.Models;

namespace Software_Lanch.Context
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
       
        #region DbSet<T>
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanch> Lanchs { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
        #endregion
        #region Ctor
        public AppDbContext(DbContextOptions<AppDbContext>option):base(option){ }
        #endregion
        #region OnModelCreating
        //protected override void OnModelCreating(ModelBuilder mb)
        //{

        //    mb.Entity<CarrinhoCompraItem>(c =>
        //    {
        //        c.ToTable("tbCarrinhoCompraItem");
        //        c.HasKey(p => p.Id);
        //        c.Property(p => p.CarrinhoCompraId).HasMaxLength(200);
        //    });
        //    //Popular tabela

        //    mb.Entity<Categoria>(c =>
        //    {
        //        c.ToTable("tbCategoria");
        //        c.HasKey(p => p.Id);
        //        c.Property(p => p.CategoriaNome).IsRequired().HasMaxLength(150);
        //        c.Property(p => p.Descricao).HasMaxLength(300);
        //    });
        //    mb.Entity<Lanch>(l =>
        //    {
        //        l.ToTable("tbLanche");
        //        l.HasKey(p => p.Id);
        //        l.Property(p => p.Nome).IsRequired().HasMaxLength(150);
        //        l.Property(p => p.DescricaoCurta).IsRequired().HasMaxLength(150);
        //        l.Property(p => p.ImagemUrl).HasMaxLength(350);
        //        l.Property(p => p.Preco).HasPrecision(10, 2).IsRequired();
        //        l.Property(p => p.CategoriaId).IsRequired();

        //    });
        //    mb.Entity<Pedido>(l =>
        //    {
        //        l.ToTable("tbPedido");
        //        l.HasKey(l => l.Id);
        //    }
        //    );
        //    mb.Entity<PedidoDetalhe>(l =>
        //    {
        //        l.ToTable("tbPedidoDetalhe");
        //        l.HasKey(l => l.Id);
        //    }
        //    );
        //    //RELAICIONAMENTO 1:N
        //    mb.Entity<Lanch>().
        //        HasOne(p => p.Categoria).WithMany(p => p.Lanchs).HasForeignKey(p => p.CategoriaId);

        //}
        #endregion
    }
}
