using CapituloApi.Interfaces;
using CapituloApi.Models;
using CapituloApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapituloApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariRepository _usuariRepository;

        public UsuarioController (IUsuariRepository usuariRepository)
        {
            _usuariRepository = usuariRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuariRepository.ListarUsuario());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        [HttpGet("(Id)")]
        public IActionResult BuscarUsuario(int Id) 
        {
            try
            {
                Usuario usuario = _usuariRepository.BuscarPorIdUsuario(Id);

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario) 
        {
            try
            {
                _usuariRepository.CadastrarUsuario(usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut("(Id)")]
        public IActionResult Atualizar(int Id, Usuario usuario)
        {
            try
            {
                _usuariRepository.AtualizarUsuario(Id, usuario);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        [HttpDelete("(Id)")]
        public IActionResult Deletar(int Id)
        {
            try
            {
                _usuariRepository.DeletarUsuario(Id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw;
            }

        }

    }
}
