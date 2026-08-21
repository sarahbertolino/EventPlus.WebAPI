using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicao _instituicao;

        public InstituicaoController(IInstituicao instituicao)
        {
            _instituicao = instituicao;
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarporId(Guid id)
        {

            try
            {
                var tipo = await _instituicao.BuscarPorId(id);
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
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] InstituicaoDTO dto)
        {
            try
            {
                var instituicao = new Instituicao
                {
                    Cnpj = dto.Cnpj,
                    NomeFantasia = dto.NomeFantasia,
                    Endereco = dto.Endereco,
                };

                await _instituicao.Cadastrar(instituicao);
                return StatusCode(201, instituicao);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] InstituicaoDTO dto)
        {
            try
            {

                var instituicao = new Instituicao
                {
                    Cnpj = dto.Cnpj,
                    NomeFantasia = dto.NomeFantasia,
                    Endereco = dto.Endereco,
                };

                // chama o métrodo atualizar e passa o Id de quem quer atualizar e o objeto
                await _instituicao.Atualizar(id, instituicao);
                return NoContent();
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
                var tipos = await _instituicao.Listar();
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
                await _instituicao.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
