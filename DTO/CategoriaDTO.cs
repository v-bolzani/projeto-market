using System.ComponentModel.DataAnnotations;

namespace Market.DTO
{
    public class CategoriaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Nome de categoria é obrigatório.")]
        [StringLength(100, ErrorMessage="Tente um nome menor.")]
        [MinLength(2, ErrorMessage="Tente um nome maior.")]
        public string Nome { get; set; }
    }
}