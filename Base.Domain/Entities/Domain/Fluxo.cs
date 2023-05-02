using Base.Infrastructure.CrossCutting.Enums;

namespace Base.Domain.Entities.Domain
{
    public class Fluxo
    {
        decimal Valor { get; set; }
        TipoPagamnento TipoPagamnento { get; set; }
    }
}
