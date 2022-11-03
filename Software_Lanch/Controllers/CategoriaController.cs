using Microsoft.AspNetCore.Mvc;
using Software_Lanch.Context;

namespace Software_Lanch.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _context;
        public CategoriaController(AppDbContext context)=>_context = context;   
        public IActionResult Index()
        {
            var categoria = _context.Categorias;
            return View(categoria);
        }
    }
}
