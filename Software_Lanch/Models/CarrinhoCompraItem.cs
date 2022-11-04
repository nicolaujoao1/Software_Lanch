using System.ComponentModel.DataAnnotations;

namespace Software_Lanch.Models
{
    public class CarrinhoCompraItem:Base
    {
        public Lanch Lanch { get; set; }
        //public int LanchId { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
 