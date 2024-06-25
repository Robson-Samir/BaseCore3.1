namespace Base.Domain.Entities.Domain
{
    public class Pedido
    {
        public int IdUser { get; set; }
        public int NumeroPedido { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string EnderecoEntrega { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
