using ClubePromocoesAPI.Commands.LojaModule.Command;
using ClubePromocoesAPI.Commands.PromocaoModule.Command;
using ClubePromocoesAPI.Reads.PromocaoModule.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClubePromocoesAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PromocaoController(IMediator handle)
        {
            _mediator = handle;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodas(int? pageNumber, int? pageSize)
        {
            try
            {
                var promocoes = await _mediator.Send(new ObterTodasPromocoesQuery(pageNumber, pageSize));
                return Ok(promocoes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var promocao = await _mediator.Send(new ObterPromocaoPorIdQuery(id));
                return Ok(promocao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarPromocaoCommand adicionarPromocaoCommand)
        {
            try
            {
                var result = await _mediator.Send(adicionarPromocaoCommand);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] EditarPromocaoCommand editarPromocaoCommand)
        {
            try
            {
                editarPromocaoCommand.Id = id;
                var result = await _mediator.Send(editarPromocaoCommand);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeletarPromocaoCommand(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
