using System.ComponentModel.DataAnnotations;

namespace Market.DTO
{
    public class PromocaoDTO
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage="Tente um nome menor.")]
        [MinLength(2, ErrorMessage="Tente um nome maior.")]
        public string Nome { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        [Range(0,100)]
        public float Porcentagem { get; set; }
    }
}