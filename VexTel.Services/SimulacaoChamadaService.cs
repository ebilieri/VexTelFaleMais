using System;
using System.Collections.Generic;
using VexTel.Domain.Contracts.IServices;
using VexTel.Domain.Entities;

namespace VexTel.Services
{
    public class SimulacaoChamadaService : ISimulacaoChamadaService
    {
        private readonly IDDDService _dddService;
        private readonly IPlanoService _planoService;
        private readonly ICustoChamadaService _custoChamadaService;

        public List<string> Erros { get; set; }

        public SimulacaoChamadaService(IDDDService dddService, IPlanoService planoService,
            ICustoChamadaService custoChamadaService)
        {
            _dddService = dddService;
            _planoService = planoService;
            _custoChamadaService = custoChamadaService;
            Erros = new List<string>();
        }

        public void Simular(SimulacaoChamada simulacaoChamada)
        {
            Validar(simulacaoChamada);
            if (Erros.Count > 0)
                throw new Exception(string.Join(". ", Erros.ToArray()));

            simulacaoChamada.DDDOrigem = _dddService.GetById(simulacaoChamada.DDDOrigemId);
            simulacaoChamada.DDDDestino = _dddService.GetById(simulacaoChamada.DDDDestinoId);
            // Buscar Plano
            simulacaoChamada.Plano = _planoService.GetById(simulacaoChamada.PlanoId);
            // Buscar Custo Chamada
            CustoChamada custoChamada = _custoChamadaService.Get(simulacaoChamada.DDDOrigemId, simulacaoChamada.DDDDestinoId);

            if (custoChamada != null)
            {
                //Custo sem fale mais
                simulacaoChamada.CustoSemFaleMais = (simulacaoChamada.Tempo * custoChamada.CustoMinuto).ToString("C2");

                // Custo com fale mais
                if (simulacaoChamada.Tempo > simulacaoChamada.Plano.TempoMinutos)
                {
                    // obter total de minutos excedentes do plano selecionado
                    int minutosExcedente = simulacaoChamada.Tempo - simulacaoChamada.Plano.TempoMinutos;
                    // calcular custo com fale mais
                    simulacaoChamada.CustoComFaleMais = (minutosExcedente * custoChamada.CustoMinuto).ToString("N2");
                    // adicionar acrescimo
                    simulacaoChamada.CustoComFaleMais = (Convert.ToDecimal(simulacaoChamada.CustoComFaleMais) + Convert.ToDecimal(simulacaoChamada.CustoComFaleMais) * simulacaoChamada.Plano.CustoAdicionalMinuto / 100).ToString("C2");
                }
                else
                {
                    simulacaoChamada.CustoComFaleMais = 0.ToString("C2");
                }
            }
            else
            {
                simulacaoChamada.CustoComFaleMais = "-";
                simulacaoChamada.CustoSemFaleMais = "-";
            }
        }

        private void Validar(SimulacaoChamada simulacaoChamada)
        {
            Erros.Clear();

            if (simulacaoChamada.DDDOrigemId <= 0)
                Erros.Add("Informe o DDD de origem");

            if (simulacaoChamada.DDDDestinoId <= 0)
                Erros.Add("Informe o DDD de destino");

            if (simulacaoChamada.DDDOrigemId == simulacaoChamada.DDDDestinoId)
                Erros.Add("O DDD de Destino deve ser diferente do DDD de Origem");
           
            if (simulacaoChamada.PlanoId <= 0)
                Erros.Add("Informe o Plano Fale Mais");

            if (simulacaoChamada.Tempo <= 0)
                Erros.Add("Informe o tempo em minutos");
        }
    }
}
