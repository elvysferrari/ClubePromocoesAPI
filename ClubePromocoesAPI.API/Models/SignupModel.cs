using System.ComponentModel.DataAnnotations;

namespace ClubePromocoesAPI.API.Models
{
    public class SignupModel
    {
        [Required(ErrorMessage = "Campo Nome obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Email obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha obrigatório")]
        public string Password { get; set; }
        
    }
}
