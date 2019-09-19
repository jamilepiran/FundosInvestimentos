using System.Collections.Generic;
using System.Linq;
using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Domain.Interfaces.Repositories;
using FundosInvestimento.Domain.Interfaces.Services;

namespace FundosInvestimento.Domain.Services
{
    public class FundosService : ServiceBase<Fundos>, IFundosService
    {
        private readonly IFundosRepository _fundosRepository;

        public FundosService(IFundosRepository fundosRepository) : base(fundosRepository)
        {
            _fundosRepository = fundosRepository;
        }
    }
}
