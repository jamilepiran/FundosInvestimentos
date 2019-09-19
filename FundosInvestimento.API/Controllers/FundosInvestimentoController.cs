using AutoMapper;
using FundosInvestimento.API.Models;
using FundosInvestimento.API.ViewModels;
using FundosInvestimento.Application.Interface;
using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FundosInvestimento.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class FundosInvestimentoController : ControllerBase
    {
        private readonly IFundosAppService _fundosApp;
        private readonly IFundosService _fundosService;

        public FundosInvestimentoController(IFundosAppService fundosApp, IFundosService fundosService)
        {
            _fundosApp = fundosApp;
            _fundosService = fundosService;
        }

        [ValidateAntiForgeryToken]
        [HttpPost("[action]")]
        public InsereFundosInvestimentoResponse InsereFundosInvestimento(FundosViewModel fundos)
        {
            InsereFundosInvestimentoResponse response = new InsereFundosInvestimentoResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    var fundosDomain = Mapper.Map<FundosViewModel, Fundos>(fundos);
                    if (_fundosApp != null)
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

        //[HttpPost]
        //[Route("api/FundosInvestimento/ListaFundosInvestimento")]
        //public ListaFundosInvestimentoResponse ListaFundosInvestimento([FromBody] ListaFundosInvestimentoRequest request)
        //{
        //    return null;
        //}
    }
}
