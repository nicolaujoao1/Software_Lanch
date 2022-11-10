using Microsoft.AspNetCore.Mvc;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Components
{
    public class CategoriaMenu:ViewComponent
    {
        private ICategoriaRepository _categoriaRepository;
        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var category = _categoriaRepository.Categorias.OrderBy(c => c.CategoriaNome);
            return View(category);
        }
    }
}
