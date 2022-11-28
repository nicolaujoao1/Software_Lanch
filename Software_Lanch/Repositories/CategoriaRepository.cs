using Microsoft.EntityFrameworkCore;
using Software_Lanch.Context;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)=>_context=context;

        public IEnumerable<Categoria> Categorias=> _context.Categorias;

        public async Task Create(Categoria categoria)
        {
            if(categoria is not null)
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task Update(Categoria categoria)
        {
            if(categoria is not null)
            {
                _context.Categorias.Update(categoria);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Categoria> GetCategoriaById(int id)
        {
            var category = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }
        public async Task Delete(int id)
        {
            var category = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
             if(category is not null) 
            { 
                _context.Categorias.Remove(category);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
