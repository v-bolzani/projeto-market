namespace Market.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public float PrecoCusto { get; set; }
        public float PrecoVenda { get; set; }
        public int Medicao { get; set; }
        public bool Status { get; set; }
    }
}