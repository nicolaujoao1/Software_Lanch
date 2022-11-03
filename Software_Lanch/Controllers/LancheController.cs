using Microsoft.AspNetCore.Mvc;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILanchRepository _lancheRepository;
        public LancheController(ILanchRepository lanchRepository)=>_lancheRepository=lanchRepository;
        public IActionResult Index()
        { 
            var lanches = _lancheRepository.Lanches;
            return View(lanches);
        }
    }
}
