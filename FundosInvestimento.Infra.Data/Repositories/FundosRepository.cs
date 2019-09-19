using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Domain.Interfaces.Repositories;
using FundosInvestimento.Infra.Data.Contexto;

namespace FundosInvestimento.Infra.Data.Repositories
{
    public class FundosRepository : RepositoryBase<Fundos>, IFundosRepository
    {
        public FundosRepository(FundosInvestimentoContext options) : base(options)
        {
        }
    }
}