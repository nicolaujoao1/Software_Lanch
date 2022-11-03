using Software_Lanch.Models;

namespace Software_Lanch.ViewModels
{
    public class LanchListViewModel
    {
        public IEnumerable<Lanch> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
