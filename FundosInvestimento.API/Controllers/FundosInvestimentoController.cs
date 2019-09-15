using AutoMapper;
using FundosInvestimento.API.Models;
using FundosInvestimento.API.ViewModels;
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
        private readonly IFundosService _fundosService;
        private readonly IMapper _mapper;

        //Construtor
        public FundosInvestimentoController(IFundosAppService fundosApp, IFundosService fundosService, IMapper mapper)
        {
            _fundosApp = fundosApp;
            _fundosService = fundosService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public InsereFundosInvestimentoResponse InsereFundosInvestimento([FromBody] FundosViewModel fundos)
        {
            InsereFundosInvestimentoResponse response = new InsereFundosInvestimentoResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    var fundosDomain = _mapper.Map<FundosViewModel, Fundos>(fundos);
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

        //[HttpPost]
        //[Route("api/FundosInvestimento/ListaFundosInvestimento")]
        //public ListaFundosInvestimentoResponse ListaFundosInvestimento([FromBody] ListaFundosInvestimentoRequest request)
        //{
        //    return null;
        //}
    }
}
