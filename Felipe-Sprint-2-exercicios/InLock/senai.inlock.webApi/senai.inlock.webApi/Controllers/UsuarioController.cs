using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new usuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<usuarioDomain> listausuario = _usuarioRepository.Listar();

            return Ok(listausuario);
        }

        [HttpPost]
        public IActionResult Post(usuarioDomain novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        [HttpPost("Login")]
        public IActionResult Login(usuarioDomain login)
        {
            usuarioDomain usuarioBuscado = _usuarioRepository.buscarPorEmailSenha(login.Email,login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha invalidos!");
            }
            var claims = new[]
            {
                                                //Tipo de claim
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.Permissao),
                new Claim("Claim Personalizada", "Valor teste")

            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("usuarios-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "InLock.webApi",  //Emissor do token
                audience: "InLock.webApi", //Quem recebe o token, para fazer a validação
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), //Acrescenta alguns minutos á expiração do token
                signingCredentials: creds
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
