using Microsoft.EntityFrameworkCore;
using Software_Lanch.Context;

namespace Software_Lanch.Models
{
    public class CarrinhoCompra
    {
        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens{ get; set; }         
    }
}
