using Microsoft.AspNetCore.Mvc;
using Software_Lanch.Models;
using Software_Lanch.Repositories;
using Software_Lanch.Repositories.Interfaces;
using Software_Lanch.ViewModels;

namespace Software_Lanch.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILanchRepository _lanchRepository;
        private CarrinhoCompraRepository _carrinhoCompraRepository;
        public CarrinhoCompraController(ILanchRepository lanchRepository, CarrinhoCompraRepository CarrinhoCompraRepository)
        {
           _lanchRepository= lanchRepository;
            _carrinhoCompraRepository = CarrinhoCompraRepository;     
        }
        public IActionResult Index()
        {
            var carrinhoCompraItems = _carrinhoCompraRepository.GetCarrinhoCompraItens();
           
            _carrinhoCompraRepository.CarrinhoCompraItens = carrinhoCompraItems;
            var carrinhoCompraViewModel = new CarrinhoCompraViewModel()
            {
                CarrinhoCompra = _carrinhoCompraRepository,
                CarrinhoCompraTotal = _carrinhoCompraRepository.GetCarrinhoItemTotal()
            };
            return View(carrinhoCompraViewModel);
        }
        public IActionResult AdicionarItemNoCarrinhoCompra(int Id)
        {
            var lanchSelecionado = _lanchRepository.Lanches.FirstOrDefault(
                l => l.Id == Id);
            if(lanchSelecionado is not null)
            {
                _carrinhoCompraRepository.AdicionarAoCarrinho(lanchSelecionado);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoverItemDoCarrinhoCompra(int lanchId)
        {
            var lanchSelecionado = _lanchRepository.Lanches.FirstOrDefault(
                l=>l.Id==lanchId);
            if (lanchSelecionado is not null)
                _carrinhoCompraRepository.RemoverDoCarrinho(lanchSelecionado);
            return RedirectToAction(nameof(Index));
          
          
        }
    }
}
