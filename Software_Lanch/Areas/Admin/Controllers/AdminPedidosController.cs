using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using Software_Lanch.Repositories.Interfaces;
using System.Data;

namespace Software_Lanch.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminPedidosController:Controller 
    {
        private readonly IPedidoRepository _pedidoRepository;
        public AdminPedidosController(IPedidoRepository pedidoRepository)
            =>_pedidoRepository= pedidoRepository;
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

    }
}
