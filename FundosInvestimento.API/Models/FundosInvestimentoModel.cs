using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FundosInvestimento.Domain.Entities;

namespace FundosInvestimento.API.Models
{
    #region Insere Fundos de Investimento
    public class InsereFundosInvestimentoRequest
    {
        public Guid fundosId { get; set; }
        public string nome { get; set; }
        public string cnpj { get; set; }
        public decimal investimentoInicial { get; set; }
    }

    public class InsereFundosInvestimentoResponse
    {
        public string mensagem { get; set; }
    }
    #endregion

    #region Lista Fundos de Investimento
    public class ListaFundosInvestimentoRequest
    {
        //public string Token { get; set; }
        //public int PceId { get; set; }
        //public string CPFMotorista { get; set; }
    }

    public class ListaFundosInvestimentoItemResponse
    {
        //public int PceId { get; set; }
        //public string CodigoAmostra { get; set; }
        //public string NumeroLaudo { get; set; }
        //public string CPFMotorista { get; set; }
        //public string NomeMotorista { get; set; }
        //public string Telefone { get; set; }
        //public string Email { get; set; }
        //public string Arquivo { get; set; }
        //public string DataCriacao { get; set; }
        //public string DataAtualizacao { get; set; }
        //public string DatahrLiberacaoRelatorioMedico { get; set; }
        //public string StatusPrescricaoMedica { get; set; }
        //public string Observacao { get; set; }
        //public string DescricaoMotivoRejeicao { get; set; }
        //public string DescricaoMotivoRejeicaoMotorista { get; set; }
    }

    public class ListaFundosInvestimentoResponse
    {
        //public List<ListaFundosInvestimentoItemResponse> prescricaomedica = new List<ListaFundosInvestimentoItemResponse>();

        //public int CodigoErro { get; set; }
        //public string Mensagem { get; set; }

    }
    #endregion
}
