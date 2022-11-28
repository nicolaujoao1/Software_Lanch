using Software_Lanch.Models;

namespace Software_Lanch.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
        Task Create(Categoria categoria);
        Task Update(Categoria categoria);
        Task<Categoria> GetCategoriaById(int id);
        Task Delete(int id);
    }
}
