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
                lanches= _lancheRepository.Lanches.Where(l=>l.Categoria.CategoriaNome==categoria)
                    .OrderBy(l=>l.Nome);
                #region Antingo
                //if(string.Equals(categoria, "Normal", StringComparison.OrdinalIgnoreCase))
                //{
                //    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                //        .OrderBy(l => l.Id);
                //}
                //else
                //{
                //    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                //        .OrderBy(l => l.Id);
                //}
                #endregion
                categoriaAtual = categoria;
            }
            var lanchesListViewModel = new LanchListViewModel() {
                Lanches = lanches,
                CategoriaAtual = "Categoria actual"
            };
            return View(lanchesListViewModel);
        }
        public IActionResult Details(int Id)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.Id == Id);
            return View(lanche);    
        }
    }
}
