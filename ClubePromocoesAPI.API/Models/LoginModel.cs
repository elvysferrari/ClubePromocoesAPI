using System.ComponentModel.DataAnnotations;

namespace ClubePromocoesAPI.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo Email obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Password obrigatório")]
        public string Password { get; set; }
    }
}
