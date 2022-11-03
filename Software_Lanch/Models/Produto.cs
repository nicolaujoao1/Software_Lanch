namespace Software_Lanch.Models
{
    public class Produto:Base
    {
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
