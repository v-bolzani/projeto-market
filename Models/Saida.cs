using System;

namespace Market.Models
{
    public class Saida
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public float Quantidade { get; set; }
        public float ValorVenda { get; set; }
        public DateTime Data { get; set; }
        public Venda Venda { get; set; }
    }
}