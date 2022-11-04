using Software_Lanch.Context;
using Software_Lanch.Models;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch.Repositories;
public class CarrinhoCompraRepository:ICarrinhoCompraRepository
{
    private readonly AppDbContext _context;
    public CarrinhoCompraRepository(AppDbContext context)
    {
        _context = context;
    }
    public static CarrinhoCompra GetCarrinho(IServiceProvider services)
    {
         //definir uma sessão
         ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        //Obtem um serviço do tipo do nosso contexto
        var context = services.GetService<AppDbContext>();

        //obtem ou gera o ID do Carrinho
        string carrinhoId=session.GetString("CarrinhoId")??Guid.NewGuid().ToString();

        //atribui o id do carringo na sessão
        session.SetString("CarrinhoId", carrinhoId);
        var carrinhoCompra=new CarrinhoCompra() { CarrinhoCompraId = carrinhoId };
        return carrinhoCompra;
    }
}
