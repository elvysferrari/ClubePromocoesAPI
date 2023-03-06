using ClubePromocoesAPI.Domain.Base;
using ClubePromocoesAPI.Domain.Enums;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Domain.Entities
{
    public class Loja : EntityBase
    {
        public Loja() { }
        public Loja(long categoriaId, string nome, string descricao, DateTime criadaEm, string imagem, DateTime? abreAs, DateTime? fechaAs,
                    string endereco, string numero, string bairro, string cidade, string uf, bool ativo)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao= descricao;
            CriadaEm = criadaEm;
            Imagem = imagem;
            AbreAs = abreAs;
            FechaAs = fechaAs;
            Endereco = endereco;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            Ativo = ativo;
            Validar();
        }
        public long CategoriaId { get; private set; }        
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime CriadaEm { get; private set; }
        public string Imagem { get; private set; }
        public DateTime? AbreAs { get; private set; }
        public DateTime? FechaAs { get; private set; }
        public string Endereco { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public bool Ativo { get; private set; }
        public Loja InformarCategoria(long categoriaId)
        {
            CategoriaId = categoriaId;
            return this;
        }
        public Loja InformarNome(string nome)
        {
            Nome = nome;
            return this;
        }
        public Loja InformarDescricao(string descricao)
        {
            Descricao = descricao;
            return this;
        }
        public Loja InformarImagem(string imagem)
        {
            Imagem = imagem;
            return this;
        }
        public Loja InformarAbreAs(DateTime? abreAs)
        {
            AbreAs = abreAs;
            return this;
        }
        public Loja InformarFechaAs(DateTime? fechaAs)
        {
            FechaAs = fechaAs;
            return this;
        }
        public Loja InformarEndereco(string endereco)
        {
            Endereco = endereco;
            return this;
        }
        public Loja InformarNumero(string numero)
        {
            Numero = numero;
            return this;
        }
        public Loja InformarBairro(string bairro)
        {
            Bairro = bairro;
            return this;
        }
        public Loja InformarCidade(string cidade)
        {
            Cidade = cidade;
            return this;
        }
        public Loja InformarUF(string uf)
        {
            UF = uf;
            return this;
        }
        public Loja InformarAtivo(bool ativo)
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
