using System.Collections.Generic;
using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Domain.Interfaces.Repositories;
using FundosInvestimento.Domain.Interfaces.Services;

namespace FundosInvestimento.Domain.Services
{
    public class AplicacaoResgateService : ServiceBase<AplicacaoResgate>, IAplicacaoResgateService
    {
        private readonly IAplicacaoResgateRepository _aplicacaoresgateRepository;

        public AplicacaoResgateService(IAplicacaoResgateRepository aplicacaoresgateRepository)
            : base(aplicacaoresgateRepository)
        {
            _aplicacaoresgateRepository = aplicacaoresgateRepository;
        }

        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
            //return _produtoRepository.BuscarPorNome(nome);
        //}
    }
}
