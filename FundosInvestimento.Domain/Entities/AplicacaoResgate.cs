using System;
using System.Collections.Generic;
using System.Text;

namespace FundosInvestimento.Domain.Entities
{
    public class AplicacaoResgate
    {
        public Guid AplicacaoResgateId { get; set; }
        public TpMovimentacao TipoMovimentacao{ get; set; }
        public Guid FundosId { get; set; }
        public string Cpf { get; set; }
        public decimal ValorMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }

    public enum TpMovimentacao
    {
        Aplicacao,
        Resgate
    }
}
