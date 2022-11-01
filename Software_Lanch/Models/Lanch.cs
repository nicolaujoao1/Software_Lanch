using System.ComponentModel.DataAnnotations;

namespace Software_Lanch.Models
{
    public class Lanch:Base
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        [Display(Name = "Nome do Lanch")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        [Display(Name = "Descrição do Lanch")]
        [MinLength(20)]
        [MaxLength(200)]
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal Preco { get; set;    }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailURL { get; set; }
        [Display(Name ="Preferido?")]
        public bool IsLanchPreferido { get; set; }
        [Display(Name ="Estoque")]
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
