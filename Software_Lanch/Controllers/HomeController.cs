using Microsoft.AspNetCore.Mvc;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;
using Software_Lanch.ViewModels;
using System.Diagnostics;

namespace Software_Lanch.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILanchRepository _lanchRepository;
        public HomeController(ILanchRepository lanchRepository)
        =>_lanchRepository = lanchRepository;
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos=_lanchRepository.LanchesPreferidos
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}