using System.ComponentModel.DataAnnotations;

namespace TesteAPI2.Models
{
    public class UsuarioModel
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Key]
        public int Id { get; set; }

    }
}
