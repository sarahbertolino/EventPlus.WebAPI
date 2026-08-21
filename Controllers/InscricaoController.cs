using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricao _inscricaoRepository;

        public InscricaoController()
        {
            _inscricaoRepository = new InscricaoRepository();
        }

        [HttpPost]
        public IActionResult Post(Presenca presenca)
        {
            try
            {
                _inscricaoRepository.Inscrever(presenca);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_inscricaoRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_inscricaoRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Minhas/{idUsuario}")]
        public IActionResult GetMinhas(Guid idUsuario)
        {
            try
            {
                return Ok(_inscricaoRepository.ListarMinhasPresencas(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutSituacao(Guid id, [FromBody] bool situacao)
        {
            try
            {
                _inscricaoRepository.AtualizarSituacao(id, situacao);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
}
