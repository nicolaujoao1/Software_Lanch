using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;
using System.Data;

namespace Software_Lanch.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminLanchesController : Controller
    {
        private readonly ILanchRepository _lanchRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        public AdminLanchesController(ILanchRepository lanchRepository, ICategoriaRepository categoriaRepository)
        {
            _lanchRepository = lanchRepository;
            _categoriaRepository = categoriaRepository;
        }


        public async Task<IActionResult> Index(string filter,int pageindex=1, string sort = "Nome")
        {
            var lanch = _lanchRepository.GetLanchs().AsQueryable().AsNoTracking();
            if (!string.IsNullOrEmpty(filter))
            {
                lanch = lanch.Where(l => l.Nome.Contains(filter));
            }
            var model = await PagingList.CreateAsync(lanch,5,pageindex,sort,"Nome");
            model.RouteValue = new RouteValueDictionary { { "filter",filter} };
            return View(model);
        }
        //public IActionResult Index()
        //{
        //    var lanches = _lanchRepository.GetLanchs();
        //    return View(lanches);
        //}

        #region Views Create
        // GET: Admin/AdminLanches/Create
        public IActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(_categoriaRepository.GetCategorias().ToList(), "CategoriaId", "CategoriaNome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lanch lanche)
        {
            if (ModelState.IsValid)
            {
                await _lanchRepository.Create(lanche);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoriaId = new SelectList(_categoriaRepository.GetCategorias().ToList(), "CategoriaId", "CategoriaNome",lanche.Id);
            return View(lanche);
        }

        #endregion

    }
}
