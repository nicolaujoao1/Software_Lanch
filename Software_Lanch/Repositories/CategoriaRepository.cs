using Software_Lanch.Context;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)=>_context=context;

        public Task<IEnumerable<Categoria>> Categorias => throw new NotImplementedException();
    }
}
