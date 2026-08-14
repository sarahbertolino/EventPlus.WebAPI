using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]  //http://localhost:5000/api/tipoevento
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEvento _tipoEvento;

        public TipoEventoController(ITipoEvento tipoEvento)
        {
            _tipoEvento = tipoEvento;
        }

        [HttpGet] // iactionresult pega os resultados de uma ação do tipo GET
        public async Task<IActionResult> Listar()
        {
            try // se der certo, o try já é suficiente
            {
                var tipos = await _tipoEvento.Listar();
                return Ok(tipos);s
            }
            catch (Exception e) //se der errado, ñ vai quebrar o código, só vai retornar do erro
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo perfil de usuário
        /// </summary>
        /// <param name="tipoEvento">Perfil do usuário a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] TipoEventoDTO dto)
        {
            var tipoEvento = new TipoEvento
            {
                Titulo = dto.Titulo
            };

            await _tipoEvento.Cadastrar(tipoEvento);

            //return CreatedAtAction("BuscarPorId", new { id = tipoEvento.IdTipoEvento }, tipoEvento);
            return StatusCode(201, tipoEvento);
        }
    }
}
