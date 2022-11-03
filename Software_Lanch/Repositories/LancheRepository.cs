using Microsoft.EntityFrameworkCore;
using Software_Lanch.Context;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Repositories
{
    public class LancheRepository : ILanchRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext context) => _context = context;

        public IEnumerable<Lanch> Lanches =>_context.Lanchs.Include(c => c.Categoria);
        public IEnumerable<Lanch> LanchesPreferidos=>_context.Lanchs
            .Where(l => l.IsLanchPreferido).Include(c => c.Categoria);

        public Lanch GetLancheById(int lancheId)
        =>_context.Lanchs.FirstOrDefault(l => l.Id == lancheId);
    }
}
