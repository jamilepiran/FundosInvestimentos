using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundosInvestimento.Domain.Entities
{
    public class Fundos
    {
        [Key]
        public Guid FundosId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public decimal InvestimentoInicial { get; set; }

        public virtual IEnumerable<AplicacaoResgate> AplicacaoResgate { get; set; }
    }
}
