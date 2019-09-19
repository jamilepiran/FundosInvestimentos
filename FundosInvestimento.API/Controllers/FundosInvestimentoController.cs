using FundosInvestimento.API.Models;
using FundosInvestimento.Application.Interface;
using FundosInvestimento.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AutoMapper;
using FundosInvestimento.API.ViewModels;
using FundosInvestimento.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FundosInvestimento.API.Controllers
{
    [Route("api/[controller]")]
    public class FundosInvestimentoController : ControllerBase
    {
        private readonly IFundosAppService _fundosApp;

        public FundosInvestimentoController(IFundosAppService fundosApp)
        {
            _fundosApp = fundosApp;
        }

        [HttpPost("[action]")]
        //[Route("api/FundosInvestimento/InsereFundosInvestimento")]
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

                //var clienteViewModel = Mapper.Map<FundosViewModel>(Fundos)(_fundosApp.Add(dadosfundosinvestimento));

                //var retorno = Mapper.Map<FundosViewModel>(Fundos);

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
