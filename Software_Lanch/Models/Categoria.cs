using System.ComponentModel.DataAnnotations;

namespace Software_Lanch.Models
{
    public class Categoria:Base
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        public string CategoriaNome { get; set; }
        public string Descricao { get; set; }
        public List<Lanch>Lanchs { get; set; }
    }
}
