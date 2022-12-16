using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using Software_Lanch.Context;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;
using Software_Lanch.ViewModels;
using System.Data;

namespace Software_Lanch.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminPedidosController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        public AdminPedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        #region Index
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {
            var pedido = await _pedidoRepository.GetPedidosAsync();
            if (!string.IsNullOrEmpty(filter))
            {
                pedido = pedido.Where(p => p.Nome.Contains(filter));
            }
            var model = PagingList.Create(pedido, 5, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
        }
        #endregion
        #region Pedido
        public async Task<IActionResult> PedidoLanches(int id)
        {
            var pedido = await _pedidoRepository.GetLPedidoLanch(id);
            if (pedido is null)
            {
                Response.StatusCode = 404;
                return View("PedidoNotFound",id);
            }

            PedidoLanchViewModel pedidoLanchViewModel = new PedidoLanchViewModel
            {
                Pedido = (Pedido)pedido,
                PedidoDetalhes = _pedidoRepository.GetTotalItens()
            };
            return View(pedidoLanchViewModel);
        }
        #endregion
    }
}
