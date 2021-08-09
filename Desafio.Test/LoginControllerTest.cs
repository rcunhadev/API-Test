using NUnit.Framework;
using Desafio.API;
using Desafio.API.Controllers;
using Desafio.API.Models;

namespace Desafio.Test
{
    public class LoginControllerTest
    {

        [Test]
        public void GeneratePass()
        {
            Assert.IsNotNull(new LoginController().GeneratePass().Result.Value.Response);
        }

        [Test]
        public void ConfimPassword()
        {
            var param = new RequestParam 
            { 
                Request = "@Desafio123885532@" 
            };
            Assert.IsTrue(new LoginController().ConfimPassword(param).Result.Value);
        }


        [Test]
        public void GenerateToken()
        {
            var param = new LoginDto
            { 
                Login = "Teste", Password = "@Desafio123885532@" 
            };
            Assert.IsNotNull(new LoginController().GenerateToken(param).Result.Value.Token);

        }
    }
}