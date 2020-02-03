using System;
using System.Collections.Generic;
using System.Text;
using VexTel.Domain.Contracts.IServices;
using VexTel.Domain.Entities;

namespace VexTel.Services
{
    public class SimulacaoChamadaService : ISimulacaoChamadaService
    {
        private readonly IPlanoService _planoService;
        private readonly ICustoChamadaService _custoChamadaService;

        public SimulacaoChamadaService(IPlanoService planoService, 
            ICustoChamadaService custoChamadaService)
        {
            _planoService = planoService;
            _custoChamadaService = custoChamadaService;
        }
        public void Simular(SimulacaoChamada simulacaoChamada)
        {
            Plano plano = _planoService.GetById(simulacaoChamada.PlanoId);

            CustoChamada custoChamada = _custoChamadaService.Get(simulacaoChamada.DDDOrigemId, simulacaoChamada.DDDDestinoId);

            simulacaoChamada.CustoSemFaleMais = simulacaoChamada.Tempo * custoChamada.CustoMinuto;

            if (simulacaoChamada.Tempo > plano.TempoMinutos)
            {
                int minutosExcente = simulacaoChamada.Tempo - plano.TempoMinutos;
                simulacaoChamada.CustoComFaleMais = minutosExcente * custoChamada.CustoMinuto;
                // adicionar acrescimo
                simulacaoChamada.CustoComFaleMais = simulacaoChamada.CustoComFaleMais * plano.CustoAdicionalMinuto / 100;
            }else
            {
                simulacaoChamada.CustoComFaleMais = 0;//
            }
        }
    }
}
