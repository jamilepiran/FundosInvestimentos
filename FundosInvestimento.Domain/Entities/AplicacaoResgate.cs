using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundosInvestimento.Domain.Entities
{
    public abstract class AplicacaoResgate
    {
        public Guid AplicacaoResgateId { get; set; }
        public TpMovimentacao TipoMovimentacao{ get; set; }
        [ForeignKey("FundosId")]
        public Guid FundosId { get; set; }
        public string Cpf { get; set; }
        public decimal ValorMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }

        public Fundos Fundos { get; set; }
    }

    public enum TpMovimentacao
    {
        Aplicacao,
        Resgate
    }
}
