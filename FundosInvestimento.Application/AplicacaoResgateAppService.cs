using System.Collections.Generic;
using FundosInvestimento.Application.Interface;
using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Domain.Interfaces.Services;

namespace FundosInvestimento.Application
{
    public class AplicacaoResgateAppService : AppServiceBase<AplicacaoResgate>, IAplicacaoResgateAppService
    {
        private readonly IAplicacaoResgateService _aplicacaoresgateService;

        public AplicacaoResgateAppService(IAplicacaoResgateService aplicacaoresgateService) : base(aplicacaoresgateService)
        {
            _aplicacaoresgateService = aplicacaoresgateService;
        }
    }
}
