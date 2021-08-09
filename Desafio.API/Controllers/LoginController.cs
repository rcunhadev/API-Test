using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Desafio.API.Authorization;
using Desafio.API.Models;

namespace Desafio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {       

        [HttpPost("GenerateToken")]
        public async Task<ActionResult<AuthenticateUser>> GenerateToken([FromBody] LoginDto user)
        {
            using (var login = new Login()) 
            {
                if (login.SignIn(user))
                    return new Token().GenerateToken(user);

                ModelState.AddModelError(string.Empty, "Dados incorretos! Por favor, verifique usuario/senha.");
                return BadRequest(ModelState);
            }
                
        }               

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("ConfimPassword")]
        public async Task<ActionResult<bool>> ConfimPassword([FromBody] RequestParam param)
        {            
            return new AbstractValidatorPassword()
                .Validate(new Password { Pass = param.Request }).IsValid;
        }


        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GeneratePass")]
        public async Task<ActionResult<ResponseParam>> GeneratePass()
        {
            try
            {
                Guid id = Guid.NewGuid();
                return  new ResponseParam {  Response = string.Concat("@A", id, "N#") };
            }
            catch (Exception ex)
            {
                return BadRequest(string.Concat("Erro: ", ex.Message));
            }
            
        }
    }

   
}
