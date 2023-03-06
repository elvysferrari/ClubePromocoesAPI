using ClubePromocoesAPI.Domain.Base;
using ClubePromocoesAPI.Domain.Enums;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubePromocoesAPI.Domain.Entities
{
    public class Promocao : EntityBase
    {
        public Promocao() { }
        public Promocao(long lojaId, long usuarioId, DateTime criadaEm, DateTime dataInicio, DateTime dataFim,
                        string titulo, string descricao, string observacao, string imagemDestacada,
                        decimal? valorDe, decimal? valorPor, bool ativo) { 
            LojaId = lojaId;
            UsuarioId = usuarioId;
            CriadaEm = criadaEm;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Titulo  = titulo;
            Descricao = descricao;
            Observacao = observacao;
            ImagemDestacada = imagemDestacada;
            ValorDe = valorDe;
            ValorPor = valorPor;
            Ativo = ativo;
            Validar();
        }
        public long LojaId { get; private set; }
        public long UsuarioId { get; private set; }
        public DateTime CriadaEm { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Observacao { get; private set; }
        public string ImagemDestacada { get; private set; }
        public decimal? ValorDe { get; private set; }
        public decimal? ValorPor { get; private set; }
        public bool Ativo { get; private set; }

        public Promocao InformarTitulo(string titulo)
        {
            Titulo = titulo;
            return this;
        }
        public Promocao InformarDescricao(string descricao)
        {
            Descricao = descricao;
            return this;
        }
        public Promocao InformarObservacao(string observacao)
        {
            Observacao = observacao;
            return this;
        }
        public Promocao InformarDataInicio(DateTime dataInicio)
        {
            DataInicio = dataInicio;
            return this;
        }
        public Promocao InformarDataFim(DateTime dataFim)
        {
            DataFim = dataFim;
            return this;
        }
        public Promocao InformarImagemDestacada(string imagemDestacada)
        {
            ImagemDestacada = imagemDestacada;
            return this;
        }
        public Promocao InformarValorDe(decimal? valorDe)
        {
            ValorDe = valorDe;
            return this;
        }
        public Promocao InformarValorPor(decimal? valorPor)
        {
            ValorPor = valorPor;
            return this;
        }

        public Promocao InformarAtivo(bool ativo)
        {
            Ativo = ativo;
            return this;
        }
        public void Validar()
        {
            //Validate(this, new LojaValidator());
        }

    }
}
