using Software_Lanch.Models;

namespace Software_Lanch.Repositories.Interfaces;
public interface ILanchRepository
{
    IEnumerable<Lanch> Lanches { get; }
    IEnumerable<Lanch> LanchesPreferidos { get; }
    IEnumerable<Lanch> GetLanchs();
    Task<Lanch> GetLancheById(int lancheId);
    Task Create(Lanch lanch);
    Task Update(Lanch lanch);
    Task Delete(int id);
}

