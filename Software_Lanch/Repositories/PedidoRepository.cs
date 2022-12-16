using Microsoft.EntityFrameworkCore;
using Software_Lanch.Context;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;
        private readonly CarrinhoCompraRepository _carrinhoCompraRepository;
        private List<PedidoDetalhe> _totalItems;
        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompraRepository carrinhoCompraRepository)
        {
            _context = appDbContext;
            _carrinhoCompraRepository = carrinhoCompraRepository;
        }
        public async Task<IEnumerable<Pedido>> GetPedidosAsync()
         => await _context.Pedidos.AsNoTracking().ToListAsync();
        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            var carrinhoCompraItens = _carrinhoCompraRepository.CarrinhoCompraItens;
            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanch.Id,
                    PedidoId = pedido.Id,
                    Preco = carrinhoItem.Lanch.Preco
                };
                _context.PedidoDetalhes.Add(pedidoDetail);
            }
            _context.SaveChanges();



        }
       
        public async Task<object> GetLPedidoLanch(int id)
        {
            var pedido=await _context.Pedidos
                .Include(l => l.PedidoItens)
                .ThenInclude(l => l.Lanche)
                .FirstOrDefaultAsync(l => l.Id == id);
            _totalItems = pedido.PedidoItens;
            return pedido;
        }

        public List<PedidoDetalhe> GetTotalItens()
       => _totalItems;
    }
}
