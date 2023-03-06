using ClubePromocoesAPI.Commands.LojaModule.Command;
using ClubePromocoesAPI.Reads.LojaModule.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubePromocoesAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LojaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LojaController(IMediator handle)
        {
            _mediator = handle;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodas(int? pageNumber, int? pageSize)
        {
            try
            {
                var result = await _mediator.Send(new ObterTodasLojasQuery(pageNumber, pageSize));
                return Ok(result);
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
                var result = await _mediator.Send(new ObterLojaPorIdQuery(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarLojaCommand adicionarLojaCommand)
        {
            try
            {
                var result = await _mediator.Send(adicionarLojaCommand);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] EditarLojaCommand editarLojaCommand)
        {
            try
            {
                editarLojaCommand.Id = id;
                var result = await _mediator.Send(editarLojaCommand);
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
                var result = await _mediator.Send(new DeletarLojaCommand(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
