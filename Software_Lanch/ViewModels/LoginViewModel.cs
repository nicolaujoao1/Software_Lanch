


using System.ComponentModel.DataAnnotations;

namespace Software_Lanch.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Informe o nome")]
        [Display(Name="Nome")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Informe a senha")]
        [Display(Name = "senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
