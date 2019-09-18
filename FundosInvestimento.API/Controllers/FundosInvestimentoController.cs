using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundosInvestimento.API.Models;
using FundosInvestimento.Application.Interface;
using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FundosInvestimento.API.Controllers
{
    public class FundosInvestimentoController : ControllerBase
    {
        private readonly IFundosAppService _fundosApp;

        public FundosInvestimentoController(IFundosAppService fundosApp)
        {
            _fundosApp = fundosApp;
        }

        [HttpPost]
        [Route("api/FundosInvestimento/InsereFundosInvestimento")]
        public InsereFundosInvestimentoResponse InsereFundosInvestimento([FromBody] InsereFundosInvestimentoRequest request)
        {
            InsereFundosInvestimentoResponse response = new InsereFundosInvestimentoResponse();

            try
            {
                Fundos dadosfundosinvestimento = new Fundos();

                dadosfundosinvestimento.Nome = request.nome;
                dadosfundosinvestimento.Cnpj = request.cnpj;
                dadosfundosinvestimento.InvestimentoInicial = request.investimentoInicial;

                _fundosApp.Add(dadosfundosinvestimento);

                //if (retorno != null)
                //{
                //    response.mensagem = "Fundos de Investimento inserido com sucesso!";
                //}
                
            }
            catch (Exception ex)
            {
                response.mensagem = "Erro: " + ex;
                return response;
            }
            return response;
        }

        [HttpPost]
        [Route("api/FundosInvestimento/ListaFundosInvestimento")]
        public ListaFundosInvestimentoResponse ListaFundosInvestimento([FromBody] ListaFundosInvestimentoRequest request)
        {
            return null;
        }
    }
}
