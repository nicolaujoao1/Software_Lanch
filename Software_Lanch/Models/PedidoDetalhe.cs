using System.ComponentModel.DataAnnotations.Schema;

namespace Software_Lanch.Models
{
    public class PedidoDetalhe:Base
    {
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        public int LancheId { get; set; }
        public int PedidoId { get; set; }

        public Lanch Lanche { get; set; }
        public Pedido Pedido { get; set; }
    }
}
