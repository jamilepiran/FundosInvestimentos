using AutoMapper;
using FundosInvestimento.API.Models;
using FundosInvestimento.Application.Interface;
using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace FundosInvestimento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize()]
    public class FundosInvestimentoController : ControllerBase
    {
        //Fazer a injeção do serviço no repositório
        private readonly IFundosAppService _fundosApp;
        private readonly IAplicacaoResgateAppService _movimentacaoApp;
        private readonly IMapper _mapper;

        //Construtor
        public FundosInvestimentoController(IFundosAppService fundosApp, IAplicacaoResgateAppService movimentacaoApp, IMapper mapper)
        {
            _fundosApp = fundosApp;
            _movimentacaoApp = movimentacaoApp;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public InsereFundosInvestimentoResponse InsereFundosInvestimento([FromBody] InsereFundosInvestimentoRequest fundos)
        {
            InsereFundosInvestimentoResponse response = new InsereFundosInvestimentoResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    var fundosDomain = _mapper.Map<InsereFundosInvestimentoRequest, Fundos>(fundos);
                    if (fundosDomain != null)
                    {
                        _fundosApp.Add(fundosDomain);
                        response.mensagem = "Fundos de Investimento inserido com sucesso!";
                    }
                }
            }
            catch (Exception ex)
            {
                response.mensagem = "Erro: " + ex;
                return response;
            }
            return response;
        }

        [HttpPost("[action]")]
        public InsereMovimentacaoInvestimentoResponse InsereMovimentacaoInvestimento([FromBody] InsereMovimentacaoInvestimentoRequest movimentacao)
        {
            InsereMovimentacaoInvestimentoResponse response = new InsereMovimentacaoInvestimentoResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    var aplicacaoresgateDomain = _mapper.Map<InsereMovimentacaoInvestimentoRequest, AplicacaoResgate>(movimentacao);
                    if (aplicacaoresgateDomain != null)
                    {
                        _movimentacaoApp.Add(aplicacaoresgateDomain);
                        response.mensagem = "Movimentação inserida com sucesso!";
                    }
                }
            }
            catch (Exception ex)
            {
                response.mensagem = "Erro: " + ex;
                return response;
            }
            return response;
        }

        [HttpGet("[action]")]
        public IEnumerable<ListaFundosInvestimentoResponse> ListaFundosInvestimento()
        {
           
           var listafundos = _mapper.Map<ICollection<Fundos>, ICollection<ListaFundosInvestimentoResponse>>(_fundosApp.GetAll());
           return listafundos;
        }
    }
}
