using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class TipoEventoDTO
    {
        /// <summary>
        /// Título do tipo de evento.
        /// </summary>
        [Required(ErrorMessage = "O título do tipo evento é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título onde ter no máximo 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;
    }
}
