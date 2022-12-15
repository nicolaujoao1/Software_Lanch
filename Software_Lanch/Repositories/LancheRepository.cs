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

        public IEnumerable<Lanch> Lanches =>_context.Lanchs.Include(c => c.Categoria).AsNoTracking();
        public IEnumerable<Lanch> LanchesPreferidos=>_context.Lanchs
            .Where(l => l.IsLanchPreferido).Include(c => c.Categoria).AsNoTracking();

        public async Task Create(Lanch lanch)
        {
            if (lanch is not null)
            {
                _context.Lanchs.Add(lanch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var foundLanch =_context.Lanchs.FirstOrDefault(l=>l.Id==id);
            if(foundLanch is not null)
            {
                _context.Lanchs.Remove(foundLanch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Lanch> GetLancheById(int lancheId)
        =>await _context.Lanchs.FirstOrDefaultAsync(l => l.Id == lancheId);

        public IEnumerable<Lanch> GetLanchs() => _context.Lanchs.Include(p=>p.Categoria).OrderBy(l=>l.Id).AsNoTracking();

        public async Task Update(Lanch lanch)
        {

            if(lanch is not null)
            {
                _context.Lanchs.Update(lanch);
                await _context.SaveChangesAsync();  
            }
        }
    }
}
