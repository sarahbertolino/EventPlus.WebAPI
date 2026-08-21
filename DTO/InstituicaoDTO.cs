using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class InstituicaoDTO
    {
        [Required(ErrorMessage = "O CNPJ é obrigatório para autenticação!")]
        [StringLength(14, ErrorMessage = "Informe um CNPJ válido!")]
        public string Cnpj { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Nome Fantasia é obrigatório para autenticação!")]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "O Nome Fantasia deve estar entre 8 e 60 caracteres.")]
        public string NomeFantasia { get; set; } = string.Empty;

        [Required(ErrorMessage = "O endereço é obrigatório para autenticação!")]
        [StringLength(250, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 250 caracteres.")]
        public string Endereco { get; set; } = string.Empty;
    }
}
