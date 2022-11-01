using Microsoft.EntityFrameworkCore;
using Software_Lanch.Context;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Repositories
{
    public class LancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lanch>> Lanches() => await _context.Lanchs.Include(c => c.Categoria).ToListAsync();


        public async Task<IEnumerable<Lanch>> LanchesPreferidos() => await _context.Lanchs.Where(l => l.IsLanchPreferido).Include(c => c.Categoria).ToListAsync();

        public async Task<Lanch> GetLancheById(int lancheId) => await _context.Lanchs.FirstOrDefaultAsync(l => l.Id == lancheId);
    }
}
