using System;
using System.Collections.Generic;
using System.Text;

namespace VexTel.Domain.Entities
{
   public class Plano
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int TempoMinutos { get; set; }
        public decimal CustoAdicionalMinuto { get; set; }
    }
}
