using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpPost]

        public async Task<IActionResult> Cadastrar([FromBody] UsuarioDTO dto)
        {
            try
            {
                var usuario = new Usuario
                {
                    Nome = dto.Nome,
                    Email = dto.Email,
                    Senha = dto.Senha,
                    IdTipoUsuario = dto.IdTipoUsuario
                };

                await _usuario.Cadastrar(usuario);

                return StatusCode(201, usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] UsuarioDTO dto)
        {
            try
            {

                var usuario = new Usuario
                {
                    Nome = dto.Nome,
                    Email = dto.Email,
                    Senha = dto.Senha,
                    IdTipoUsuario = dto.IdTipoUsuario
                };

                // chama o métrodo atualizar e passa o Id de quem quer atualizar e o objeto
                await _usuario.Atualizar(id, usuario);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

            [HttpGet("{id:guid}")]
            public async Task<IActionResult> BuscarporId(Guid id)
            {

                try
                {
                    var tipo = await _usuario.BuscarPorId(id);
                    if (tipo == null)
                    {
                        return @NotFound();
                    }

                    return Ok(tipo);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }

            [HttpGet] // iactionresult pega os resultados de uma ação do tipo GET
            public async Task<IActionResult> Listar()
            {
                try // se der certo, o try já é suficiente
                {
                    var tipos = await _usuario.Listar();
                    return Ok(tipos);
                }
                catch (Exception e) //se der errado, ñ vai quebrar o código, só vai retornar do erro
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{id:guid}")]
            public async Task<IActionResult> Deletar(Guid id)
            {
                try
                {
                    await _usuario.Deletar(id);
                    return NoContent();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
        }
    }

