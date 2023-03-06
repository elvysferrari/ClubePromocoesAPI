namespace ClubePromocoesAPI.Reads.PromocaoModule.DTOs
{
    public class PromocaoDTO
    {
        public int Id { get; set; }
        public int LojaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime CriadaEm { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string ImagemDestacada { get; set; }
        public decimal? ValorDe { get; set; }
        public decimal? ValorPor { get; set; }
        public bool Ativo { get; set; }
        public string LojaNome { get; set; }
        public string LojaDescricao { get; set; }
        public string UsuarioNome { get; set; }
    }
}
