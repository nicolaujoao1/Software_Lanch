using Software_Lanch.Models;

namespace Software_Lanch.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        Task<IEnumerable<Lanch>> Lanches { get; }
        Task<IEnumerable<Lanch>> LanchesPreferidos { get; }
        Task<Lanch> GetLancheById(int lancheId);
    }
}
