using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Reads.UsuarioModule.DTOs
{
    public class UsuarioAutenticadoDTO
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }                
        public bool Liberada { get; set; }
    }
}
