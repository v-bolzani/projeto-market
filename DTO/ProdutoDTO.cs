using System.ComponentModel.DataAnnotations;

namespace Market.DTO
{
    public class ProdutoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage="Tente um nome menor.")]
        [MinLength(2, ErrorMessage="Tente um nome maior.")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Categoria do produto é obrigatório.")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage="Fornecedor do produto é obrigatório.")]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage="Preço de custo do produto é obrigatório.")]
        public float PrecoCusto { get; set; }

        [Required(ErrorMessage="Preço de venda do produto é obrigatório.")]
        public string PrecoCustoString { get; set; }

        [Required(ErrorMessage="Preço de venda do produto é obrigatório.")]
        public float PrecoVenda { get; set; }

        [Required(ErrorMessage="Preço de venda do produto é obrigatório.")]
        public string PrecoVendaString { get; set; }

        [Required(ErrorMessage="Medição do produto é obrigatório.")]
        [Range(0,2,ErrorMessage="Medição inválida.")]
        public int Medicao { get; set; }
    }
}