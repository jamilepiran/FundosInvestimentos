using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Domain.Interfaces.Repositories;

namespace FundosInvestimento.Infra.Data.Repositories
{
    public class FundosRepository : RepositoryBase<Fundos>, IFundosRepository
    { 
    }
}