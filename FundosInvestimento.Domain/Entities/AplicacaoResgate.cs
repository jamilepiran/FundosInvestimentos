using System;
using System.Collections.Generic;
using System.Text;

namespace FundosInvestimento.Domain.Entities
{
    public class AplicacaoResgate
    {
        public Guid Id { get; set; }
        public TpMovimentacao TipoMovimentacao{ get; set; }
        public Guid FundoId { get; set; }
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
