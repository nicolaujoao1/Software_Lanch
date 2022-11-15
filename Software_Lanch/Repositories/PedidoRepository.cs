using Software_Lanch.Context;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;
        private readonly CarrinhoCompraRepository _carrinhoCompraRepository;   
        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompraRepository carrinhoCompraRepository)
        {
            _context=appDbContext;  
            _carrinhoCompraRepository=carrinhoCompraRepository; 
        }
        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            var carrinhoCompraItens =_carrinhoCompraRepository.CarrinhoCompraItens;
            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe
                {
                    Quantidade= carrinhoItem.Quantidade,
                    LancheId=carrinhoItem.Lanch.Id,
                    PedidoId=pedido.Id,
                    Preco=carrinhoItem.Lanch.Preco
                };
             _context.PedidoDetalhes.Add(pedidoDetail);
            }
            _context.SaveChanges();



        }
    }
}
