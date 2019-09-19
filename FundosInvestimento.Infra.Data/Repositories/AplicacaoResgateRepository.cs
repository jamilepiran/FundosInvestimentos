using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Domain.Interfaces.Repositories;
using FundosInvestimento.Infra.Data.Contexto;

namespace FundosInvestimento.Infra.Data.Repositories
{
    public class AplicacaoResgateRepository : RepositoryBase<AplicacaoResgate>, IAplicacaoResgateRepository
    {
        public AplicacaoResgateRepository(FundosInvestimentoContext options) : base(options)
        {
        }
    }
}