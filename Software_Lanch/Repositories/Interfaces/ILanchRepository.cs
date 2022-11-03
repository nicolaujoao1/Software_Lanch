using Software_Lanch.Models;

namespace Software_Lanch.Repositories.Interfaces
{
    public interface ILanchRepository
    {
        IEnumerable<Lanch> Lanches { get; }
        IEnumerable<Lanch> LanchesPreferidos { get; }
        Lanch GetLancheById(int lancheId);
    }
}
