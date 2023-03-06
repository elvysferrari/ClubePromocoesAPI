using ClubePromocoesAPI.API.Models;
using ClubePromocoesAPI.API.Services;
using ClubePromocoesAPI.Reads.UsuarioModule.DTOs;
using ClubePromocoesAPI.Reads.UsuarioModule.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubePromocoesAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator handle)
        {
            _mediator = handle;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioAutenticadoDTO>> Autenticar([FromBody] LoginModel loginModel)
        {
            try
            {
                var user = await _mediator.Send(new ValidaLoginUsuarioQuery(loginModel.Email, loginModel.Password));

                if (user?.Id == null || user?.Id == 0)
                    return NotFound(new UsuarioAutenticadoDTO());

                // Gera o Token
                var token = TokenService.GenerateToken(user);

                // Retorna os dados
                return Ok(new { Successful = true, Message = "Usuário logado com sucesso!", Token = token, Usuario = user });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }           
        }

        [HttpPost]
        [Route("criar-usuario")]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioAutenticadoDTO>> CriarUsuario([FromBody] SignupModel signupModel)
        {
            try
            {
                var result = await _mediator.Send(new AdicionarUsuarioQuery(signupModel.Nome, signupModel.Email, signupModel.Password));

                if (result != "success")
                    return Ok(new { Successful = false, Message = result });

                //Se deu true, criou o usuário e ja posso retornar o token
                var user = await _mediator.Send(new ValidaLoginUsuarioQuery(signupModel.Email, signupModel.Password));                

                // Gera o Token
                var token = TokenService.GenerateToken(user);

                // Retorna os dados
                return Ok(new { Successful = true, Message = "Usuário cadastrado com sucesso!", Token = token, Usuario = user });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioAutenticadoDTO>> ObterPorId(int id)
        {
            try
            {
                var user = await _mediator.Send(new ObterUsuarioPorIdQuery(id));

                if (user != null)
                {
                    var token = TokenService.GenerateToken(user);

                    // Retorna os dados
                    return Ok(new { Successful = true, Message = "Sucesso!", Token = token, Usuario = user });
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
