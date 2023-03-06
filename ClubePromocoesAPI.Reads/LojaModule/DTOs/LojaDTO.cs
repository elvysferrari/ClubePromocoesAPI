namespace ClubePromocoesAPI.Reads.LojaModule.DTOs
{
    public class LojaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }        
        public DateTime CriadaEm { get; set; }
        public string Imagem { get; set; }
        public DateTime? AbreAs { get; set; }
        public DateTime? FechaAs { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public bool Ativo { get; set; }
    }
}
