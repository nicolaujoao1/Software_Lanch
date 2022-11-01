using Microsoft.EntityFrameworkCore;
using Software_Lanch.Models;

namespace Software_Lanch.Context
{
    public class AppDbContext:DbContext
    {
        #region DbSet<T>
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanch> Lanchs { get; set; }
        #endregion
        #region Ctor
            public AppDbContext(DbContextOptions<AppDbContext>option):base(option){ }
        #endregion
        
    }
}
