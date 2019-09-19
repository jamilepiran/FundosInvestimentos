using FundosInvestimento.Application.Interface;
using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Domain.Interfaces.Services;

namespace FundosInvestimento.Application
{
    public class FundosAppService : AppServiceBase<Fundos>, IFundosAppService
    {
        private readonly IFundosService _fundosService;

        public FundosAppService(IFundosService fundosService)
            : base(fundosService)
        {
            _fundosService = fundosService;
        }

        //public IEnumerable<Cliente> ObterClientesEspeciais()
        //{
        //    return _clienteService.ObterClientesEspeciais(_clienteService.GetAll());
        //}
    }
}
