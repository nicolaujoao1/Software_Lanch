using Microsoft.AspNetCore.Mvc;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;
using Software_Lanch.ViewModels;

namespace Software_Lanch.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILanchRepository _lancheRepository;
        public LancheController(ILanchRepository lanchRepository)=>_lancheRepository=lanchRepository;
        public IActionResult Index(string categoria)
        {

            IEnumerable<Lanch> lanches=null;
            string categoriaAtual=string.Empty;
            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.
                    OrderBy(l => l.Id);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                if(string.Equals(categoria, "Normal", StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                        .OrderBy(l => l.Id);
                }
                else if(string.Equals(categoria, "Natural", StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                        .OrderBy(l => l.Id);
                }
                categoriaAtual = categoria;
            }
            var lanchesListViewModel = new LanchListViewModel() {
                Lanches = lanches,
                CategoriaAtual = "Categoria actual"
            };
            return View(lanchesListViewModel);
        }
    }
}
