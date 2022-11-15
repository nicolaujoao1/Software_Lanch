using Microsoft.AspNetCore.Mvc;
using Software_Lanch.Models;
using Software_Lanch.Repositories;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompraRepository _carrinhoCompraRepository;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompraRepository carrinhoCompraRepository)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompraRepository = carrinhoCompraRepository;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CheckoutCompleto() => View();

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItensPedido = 0;
            decimal precoTotalItensPedido = 0.0m;

            //Obter os itens do carrinho de compra do Cliente
            List<CarrinhoCompraItem> items = _carrinhoCompraRepository.GetCarrinhoCompraItens();
            _carrinhoCompraRepository.CarrinhoCompraItens=items;

            //Verificar se existe itens de pedido 
            if (items.Count() == 0)
                ModelState.AddModelError("", $"O seu carrinho de compra possui ({items.Count}) quantidade de itens.");
           
            //Calcular o total de item e total de pedido
            foreach (var itemPedido in items)
            {
                totalItensPedido += itemPedido.Quantidade;
                precoTotalItensPedido += (itemPedido.Quantidade * itemPedido.Lanch.Preco);
            }

            //Atribuir os valores obtidos ao Pedido
            pedido.TotalItensPedido = totalItensPedido;
            pedido.PedidoTotal = precoTotalItensPedido;

            //Validar os dados do Pedido
            if (ModelState.IsValid)
            {
                //Criar Pedido e os Detalhes
                _pedidoRepository.CriarPedido(pedido);

                //Definir as Messagens para o Usuario/Cliente
                ViewBag.CheckoutMessagemConcluido = "Obrigado pelo seu pedido :)";
                ViewBag.PedidoTotal = _carrinhoCompraRepository.GetCarrinhoItemTotal();

                //Limpar o Carrinho do CLiente
                _carrinhoCompraRepository.LimparCarrinho();

                //Exibe a View com os dados do Pedido
                return View(nameof(CheckoutCompleto), pedido);

            }
            else
            {
                return View(pedido);
            }

 
        }
    }
}
