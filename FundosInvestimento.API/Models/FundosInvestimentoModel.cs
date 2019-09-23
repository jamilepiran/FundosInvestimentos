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

    public class FundosInvestimentoModel
    {
        [Key] public Guid FundosId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public decimal InvestimentoInicial { get; set; }

        public virtual IEnumerable<AplicacaoResgateModel> AplicacaoResgate { get; set; }
    }

    #endregion
}
