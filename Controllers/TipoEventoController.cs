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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarporId(Guid id)
        {

            try
            {
                var tipo = await _tipoEvento.BuscarPorId(id);
                if (tipo == null)
                {
                    return NotFound();
                }

                return Ok(tipo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            //var tipoEventoBuscado = await _tipoEvento.BuscarPorId(id);

            //if (tipoEventoBuscado == null)
            //{
            //    return NotFound("Tipo de evento não encontrado.");
            //}

            //return Ok(tipoEventoBuscado);
        }

        [HttpGet] // iactionresult pega os resultados de uma ação do tipo GET
        public async Task<IActionResult> Listar()
        {
            try // se der certo, o try já é suficiente
            {
                var tipos = await _tipoEvento.Listar();
                return Ok(tipos);
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
        /// <returns></returns> ,n    
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] TipoEventoDTO dto)
        {
            try
            {
                var tipoEvento = new TipoEvento
                {
                    Titulo = dto.Titulo
                };

                await _tipoEvento.Cadastrar(tipoEvento);
                return StatusCode(201, tipoEvento);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] TipoEventoDTO dto)
        {
            try
            {

                var tipoEvento = new TipoEvento
                {
                    Titulo = dto.Titulo
                };

                // chama o métrodo atualizar e passa o Id de quem quer atualizar e o objeto
                await _tipoEvento.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


            //var tipoEvento = new TipoEvento
            //{
            //    Titulo = dto.Titulo
            //};
            //await _tipoEvento.Atualizar(id, tipoEvento);
            //return Ok(tipoEvento);
        }


        /// <summary>
        /// Remove uma cateoria de evento 
        /// </summary>
        /// <param name="id">Id do objeto a ser excluido</param>
        /// <returns>status code NoContente se der certo</returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {

            try
            {
                await _tipoEvento.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            //{
            //    await _tipoEvento.Deletar(id);
            //    return NoContent();
            //}
            //return CreatedAtAction("BuscarPorId", new { id = tipoEvento.IdTipoEvento }, tipoEvento);
        }
    }
    }

