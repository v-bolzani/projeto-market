using System.ComponentModel.DataAnnotations;

namespace Market.DTO
{
    public class FornecedorDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Nome de fornecedor é obrigatório.")]
        [StringLength(100, ErrorMessage="Tente um nome menor.")]
        [MinLength(2, ErrorMessage="Tente um nome maior.")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Email é obrigatório.")]
        [EmailAddress(ErrorMessage="Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage="Telefone é obrigatório.")]
        [Phone(ErrorMessage="Número de telefone inválido.")]
        public string Telefone { get; set; }
    }
}