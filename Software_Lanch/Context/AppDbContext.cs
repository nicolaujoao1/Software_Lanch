using Microsoft.EntityFrameworkCore;
using Software_Lanch.Models;

namespace Software_Lanch.Context
{
    public class AppDbContext:DbContext
    {
        #region Teste
        public DbSet<Produto> Produtos { get; set; }
        #endregion
        #region DbSet<T>
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanch> Lanchs { get; set; }
        #endregion
        #region Ctor
            public AppDbContext(DbContextOptions<AppDbContext>option):base(option){ }
        #endregion
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Produto>(prop =>
            {
                prop.ToTable("tbProduto");
                prop.HasKey(op => op.Id);
                prop.Property(op => op.NomeProduto).HasMaxLength(100).IsRequired();
                prop.Property(op => op.Preco).HasPrecision(10, 2).IsRequired();
                prop.Property(op=>op.Quantidade);
            }
            );
             //Popular tabela

            mb.Entity<Categoria>(c =>
            {
                c.ToTable("tbCategoria");
                c.HasKey(p => p.Id);
                c.Property(p => p.CategoriaNome).IsRequired().HasMaxLength(150);
                c.Property(p => p.Descricao).HasMaxLength(300);
            });
            mb.Entity<Lanch>(l =>
            {
                l.ToTable("tbLanche");
                l.HasKey(p => p.Id);
                l.Property(p=>p.Nome).IsRequired().HasMaxLength(150);
                l.Property(p => p.DescricaoCurta).IsRequired().HasMaxLength(150);
                l.Property(p => p.ImagemUrl).HasMaxLength(350);
                l.Property(p => p.Preco).HasPrecision(10, 2).IsRequired();
                l.Property(p => p.CategoriaId).IsRequired();
                    
            });
            ////RELAICIONAMENTO 1:N
            //mb.Entity<Lanch>().
            //    HasOne(p => p.Categoria).WithMany(p => p.Lanchs).HasForeignKey(p=>p.CategoriaId);


        }
    }
}
