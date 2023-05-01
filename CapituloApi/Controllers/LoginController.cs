using CapituloApi.Interfaces;
using CapituloApi.Models;
using CapituloApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CapituloApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize(Roles ="1")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuariRepository _usuariRepository;

        public LoginController(IUsuariRepository usuariRepository)
        {
            _usuariRepository = usuariRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            Usuario usuarioEncontrado = _usuariRepository.Login(login.Email, login.senha);
            if(usuarioEncontrado== null)
            {
                return Unauthorized(new {msg="Email e/ou senha invalidos."});
            }

            var minhasClaims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Email, usuarioEncontrado.Email),
                new Claim (JwtRegisteredClaimNames.Jti, usuarioEncontrado.Id.ToString()),
                new Claim (ClaimTypes.Role, usuarioEncontrado.Tipo)
            };

            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var meuToken = new JwtSecurityToken(
                issuer: "chapter.webapi",
                audience : "chapter.webapi",
                claims : minhasClaims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials:credenciais
            );
            return Ok(
                new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
        }
    }      
}
