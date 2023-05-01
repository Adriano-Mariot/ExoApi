using CapituloApi.Interfaces;
using CapituloApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapituloApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CapituloApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]


    //[Authorize(Roles ="1")]
    public class ProjetoController : ControllerBase
    {
       
        private readonly IProjetoRepository _iProjetoRepository;

        public ProjetoController(IProjetoRepository projetoRepository)
        {
            _iProjetoRepository = projetoRepository;
        }

      
        [HttpGet]
        public IActionResult Listar() 
        {
            try 
            {
                return Ok(_iProjetoRepository.ler());
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("(Id)")]
        public IActionResult BuscarPorId(int Id)
        {
            try
            {
                Projeto projeto = _iProjetoRepository.BuscarPorId(Id);
                if (projeto == null)
                {
                    return NotFound();
                }
                return Ok(projeto); 
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            try
            {
                _iProjetoRepository.Cadastrar(projeto);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        [HttpPut ("(Id)")]
        public IActionResult Atualizar(int Id, Projeto projeto)
        {
            try
            {
                _iProjetoRepository.Atualizar(Id, projeto);
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
                _iProjetoRepository.Deletar(Id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw;
            }

        }

    }
}
