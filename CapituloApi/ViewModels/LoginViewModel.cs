using System.ComponentModel.DataAnnotations;

namespace CapituloApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail Obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha Obrigatória")]
        public string senha { get; set; }

    }
}
