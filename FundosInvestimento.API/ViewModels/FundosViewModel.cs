﻿using FundosInvestimento.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

            public virtual IEnumerable<AplicacaoResgateViewModel> Aplicacao { get; set; }
        }
    }
}
