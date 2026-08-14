using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuario _tipoUsuario;

        public TipoUsuarioController(ITipoUsuario TipoUsuario)
        {
            _tipoUsuario = TipoUsuario;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarporId(Guid id) 
        {
            var tipoUsuarioBuscado = await _tipoUsuario.BuscarPorId(id);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound("Tipo de usuario não encontrado.");
            }

            return Ok(tipoUsuarioBuscado);
        }



        /// <summary>
        /// Lista todos os perfis de usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var tipos = await _tipoUsuario.Listar();
                return Ok(tipos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message); 
            }
        }

        /// <summary>
        /// Cadastra um novo perfil de usuário
        /// </summary>
        /// <param name="tipoUsuario">Perfil do usuário a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] TipoUsuarioDTO dto) 
        {
            var tipoUsuario = new TipoUsuario
            {
                Titulo = dto.Titulo
            };

            await _tipoUsuario.Cadastrar(tipoUsuario);

            //return CreatedAtAction("BuscarPorId", new { id = tipoUsuario.IdTipoUsuario }, tipoUsuario);
            return StatusCode(201,tipoUsuario);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] TipoUsuarioDTO dto)
        {
            var tipoUsuario = new TipoUsuario
            {
                Titulo = dto.Titulo
            };
            await _tipoUsuario.Atualizar(id, tipoUsuario);
            return Ok(tipoUsuario);
        }

        [HttpDelete("{id:guid}")]

        public async Task<IActionResult> Deletar(Guid id)
        {
            await _tipoUsuario.Deletar(id);
            return NoContent();
        }
    }
}
