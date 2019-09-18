using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundosInvestimento.Domain.Entities
{
    public class Fundos
    {
        public Guid FundosId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public decimal InvestimentoInicial { get; set; }
        [ForeignKey("FundosId")]
        public ICollection<AplicacaoResgate> AplicacaoResgate { get; set; }
    }
}
