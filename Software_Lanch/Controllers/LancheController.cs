using Microsoft.AspNetCore.Mvc;
using Software_Lanch.Repositories.Interfaces;
using Software_Lanch.ViewModels;

namespace Software_Lanch.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILanchRepository _lancheRepository;
        public LancheController(ILanchRepository lanchRepository)=>_lancheRepository=lanchRepository;
        public IActionResult Index()
        { 
            var lanches = _lancheRepository.Lanches;
            var lanchesListViewModel = new LanchListViewModel() {
                Lanches = lanches,
                CategoriaAtual = "Categoria actual"
            };
            return View(lanchesListViewModel);
        }
    }
}
