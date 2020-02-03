namespace VexTel.Domain.Entities
{
    public class CustoChamada
    {
        public int Id { get; set; }
        public int DDDOrigemId { get; set; }
        public virtual DDD DDDOrigem { get; set; }
        public int DDDDestinoId { get; set; }
        public virtual DDD DDDDestino { get; set; }        
        public decimal CustoMinuto { get; set; }   

    }
}
