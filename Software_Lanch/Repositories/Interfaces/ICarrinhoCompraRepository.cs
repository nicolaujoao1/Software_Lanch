using Software_Lanch.Models;

namespace Software_Lanch.Repositories.Interfaces
{
    public interface ICarrinhoCompraRepository
    {
       void RemoverDoCarrinho(Lanch lanch);
       void AdicionarAoCarrinho(Lanch lanch);
       List<CarrinhoCompraItem> GetCarrinhoCompraItens();
       void LimparCarrinho();
       decimal GetCarrinhoItemTotal();

    }
}
