using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FundosInvestimento.Domain.Entities;

namespace FundosInvestimento.API.Models
{
    #region Lista de Fundos de Investimentos

    public class AplicacaoResgateModel
    {
        [Key]
        public Guid AplicacaoResgateId { get; set; }
        public Domain.Entities.TpMovimentacao TipoMovimentacao { get; set; }
        [ForeignKey("FundosId")]
        public Guid FundosId { get; set; }
        public string Cpf { get; set; }
        public decimal ValorMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }

        public virtual FundosInvestimentoModel Fundos { get; set; }
    }

    public enum TpMovimentacao
    {
        Aplicacao,
        Resgate
    }

    #endregion
}
