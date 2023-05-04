using Base.Infrastructure.CrossCutting.Enums;

namespace Base.Domain.Entities.Domain
{
    public class Fluxo
    {
        public decimal Valor { get; set; }
        public TipoPagamnento TipoPagamnento { get; set; }
    }
}
