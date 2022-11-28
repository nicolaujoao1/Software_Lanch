using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminCategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoryRepository;
        public AdminCategoriasController(ICategoriaRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categorias = _categoryRepository.Categorias;
            return View(categorias);
        }

        #region Create
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.Create(categoria);
                return RedirectToAction(nameof(Index), "AdminCategorias");
            }
            return View();
        }
        #endregion
        #region Edit
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var categoria=await _categoryRepository.GetCategoriaById(id);
            if (categoria is not null)
                return View(categoria);
            return RedirectToAction(nameof(Index), "AdminCategorias");
        }
        [HttpPost("{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {
            if (id != categoria.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                await _categoryRepository.Update(categoria);
                return RedirectToAction(nameof(Index), "AdminCategorias");
            }
            return View();
        }
        #endregion
        #region Details
        public async Task<IActionResult> Details(int id)
        {
            
                var categoria = await _categoryRepository.GetCategoriaById(id);
                if (categoria is not null)
                    return View(categoria);
                return RedirectToAction(nameof(Index), "AdminCategorias");
             
        }
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoryRepository.GetCategoriaById(id);
            if (categoria is not null)
                return View(categoria);
            return RedirectToAction(nameof(Index), "AdminCategorias");
        }
        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryRepository.Delete(id);
            return RedirectToAction(nameof(Index), "AdminCategorias");
        }
        #endregion
    }
}
