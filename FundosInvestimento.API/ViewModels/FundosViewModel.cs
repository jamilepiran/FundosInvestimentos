using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FundosInvestimento.Domain.Entities;

namespace FundosInvestimento.API.ViewModels
{
    public class FundosViewModel
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
}
