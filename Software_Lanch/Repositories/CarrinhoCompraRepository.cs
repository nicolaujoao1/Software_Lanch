using Microsoft.EntityFrameworkCore;
using Software_Lanch.Context;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Repositories;
public class CarrinhoCompraRepository
    :CarrinhoCompra
{
    private readonly AppDbContext _context;
    public CarrinhoCompraRepository(AppDbContext context)
    {
        _context = context;
    }
    public static CarrinhoCompraRepository GetCarrinho(IServiceProvider services)
    {
        //definir uma sessão
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        //Obter um o do tipo do nosso contexto(AppDbContext)
        var context = services.GetService<AppDbContext>();

        //obtem ou gera o ID do Carrinho
        string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

        //atribui o id do carringo na sessão
        session.SetString("CarrinhoId", carrinhoId);


        var carrinhoCompra = new CarrinhoCompraRepository(context) { CarrinhoCompraId = carrinhoId };
        return carrinhoCompra;
    }
    public void RemoverDoCarrinho(Lanch lanche)
    {

        var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
             s => s.Lanch.Id == lanche.Id && s.CarrinhoCompraId == CarrinhoCompraId
             );
        if (carrinhoCompraItem is not null)
        {
            if (carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
            }
            else
            {
                _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
            }
        }
        _context.SaveChanges();
    }
    public void AdicionarAoCarrinho(Lanch lanch)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
            s => s.Lanch.Id == lanch.Id && s.CarrinhoCompraId == CarrinhoCompraId
            );
        if (carrinhoCompraItem is null)
        {
            carrinhoCompraItem = new CarrinhoCompraItem()
            {
                CarrinhoCompraId = CarrinhoCompraId,
                Lanch = lanch,
                Quantidade = 1
            };
            _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
        }  
        else
        {
            carrinhoCompraItem.Quantidade++;
        }
        _context.SaveChanges();
    }
    public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
    {
        return CarrinhoCompraItens ??
            (
              CarrinhoCompraItens = _context.CarrinhoCompraItens
             .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
             .Include(c => c.Lanch).ToList()
             );
    }
    public void LimparCarrinho()
    {
        var carrinhoItens = _context.CarrinhoCompraItens
            .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);
        _context.RemoveRange(carrinhoItens);
        _context.SaveChanges();
    }
    public decimal GetCarrinhoItemTotal()
    {
        var carrinhoItemTotal = _context.CarrinhoCompraItens
            .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
            .Select(c => c.Quantidade * c.Lanch.Preco)
            .Sum();
        return carrinhoItemTotal;
    }
}
