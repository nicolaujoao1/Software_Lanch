using Microsoft.AspNetCore.Mvc;
using Software_Lanch.Models;
using Software_Lanch.Repositories;
using Software_Lanch.Repositories.Interfaces;
using Software_Lanch.ViewModels;

namespace Software_Lanch.Components
{
    public class CarrinhoCompraResumo:ViewComponent
    {
       
        private readonly CarrinhoCompraRepository _carrinhoCompraRepository;
        public CarrinhoCompraResumo(CarrinhoCompraRepository carrinhoCompraRepository)
        {
            _carrinhoCompraRepository= carrinhoCompraRepository;    
            _carrinhoCompraRepository= carrinhoCompraRepository;    
        }
        public IViewComponentResult Invoke()
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
    }
}
