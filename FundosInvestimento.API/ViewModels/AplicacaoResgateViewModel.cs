using FundosInvestimento.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundosInvestimento.API.ViewModels
{
    public class AplicacaoResgateViewModel
    {
        public Guid AplicacaoResgateId { get; set; }
        public TpMovimentacao TipoMovimentacao { get; set; }
        [ForeignKey("FundosId")]
        public Guid FundosId { get; set; }
        public string Cpf { get; set; }
        public decimal ValorMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }

        public Fundos Fundos { get; set; }

        public virtual FundosViewModel Fundo { get; set; }
    }
}
