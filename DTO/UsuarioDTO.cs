using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage ="Campo obrigatorio!")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obrigatorio!")]
        [EmailAddress(ErrorMessage = "Informe um email válido!")]

        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(60, MinimumLength = 8, ErrorMessage ="A senha deve ter ebtre 8 e 60 caracteres")]
        public string Senha { get; set; } = string.Empty;

        public Guid? IdTipoUsuario { get; set; }
    }
}
