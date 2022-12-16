using Software_Lanch.Models;

namespace Software_Lanch.ViewModels
{
    public class PedidoLanchViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
