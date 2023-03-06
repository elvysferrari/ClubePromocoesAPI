using ClubePromocoesAPI.Domain.Base;

namespace ClubePromocoesAPI.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario() { }
        public Usuario(string nome, string email, string password)
        {
            Nome = nome;
            Email = email;            
            Password = password;                  
            CriadoEm = DateTime.Now;
        }
        public string Nome { get; private set; }
        public string Email { get; private set; } 
        public string Password { get; private set; }  
        public DateTime? CriadoEm { get; private set; }
        public bool Liberada { get; private set; }
    }
}
