﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FundosInvestimento.Domain.Entities;

namespace FundosInvestimento.API.Models
{
    #region Insere Fundos de Investimento
    public class InsereFundosInvestimentoRequest
    {
        public Guid FundosId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public decimal InvestimentoInicial { get; set; }
    }

    public class InsereFundosInvestimentoResponse
    {
        public string mensagem { get; set; }
    }
    #endregion

    #region Insere as Movimentações do Investimento
    public class InsereMovimentacaoInvestimentoRequest
    {
        public Guid AplicacaoResgateId { get; set; }
        public TpMovimentacao TipoMovimentacao { get; set; }
        [ForeignKey("FundosId")] public Guid FundosId { get; set; }
        public string Cpf { get; set; }
        public decimal ValorMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }

        //public Fundos Fundos { get; set; }

        //public virtual InsereFundosInvestimentoRequest Fundo { get; set; }
    }
    public class InsereMovimentacaoInvestimentoResponse
    {
        public string mensagem { get; set; }
    }
    #endregion

    #region Lista de Fundos de Investimentos

    public class ListaFundosInvestimentoItemResponse
    {
        public Guid FundosId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public decimal InvestimentoInicial { get; set; }
    }
    public class ListaFundosInvestimentoResponse
    {
        public IEnumerable<ListaFundosInvestimentoItemResponse> Fundos { get; set; }
    }
    #endregion
}
