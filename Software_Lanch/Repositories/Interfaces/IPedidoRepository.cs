using Software_Lanch.Models;

namespace Software_Lanch.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
        Task<IEnumerable<Pedido>> GetPedidosAsync();
        Task<Object> GetLPedidoLanch(int id);
        List<PedidoDetalhe> GetTotalItens();
    }
}
