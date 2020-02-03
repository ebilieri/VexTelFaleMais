namespace VexTel.Domain.Entities
{
    public class SimulacaoChamada
    {
        public int Id { get; set; }
        public int DDDOrigemId { get; set; }
        public virtual DDD DDDOrigem { get; set; }
        public int DDDDestinoId { get; set; }
        public virtual DDD DDDDestino { get; set; }
        public int PlanoId { get; set; }
        public virtual Plano Plano { get; set; }
        public int Tempo { get; set; }
        public decimal CustoComFaleMais { get; set; }
        public decimal CustoSemFaleMais { get; set; }   

    }
}
