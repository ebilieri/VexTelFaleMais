﻿using System;
using System.Collections.Generic;
using System.Text;
using VexTel.Domain.Entities;

namespace VexTel.Domain.Contracts.IServices
{
    public interface ISimulacaoChamadaService
    {
        void Simular(SimulacaoChamada simulacaoChamada);
    }
}