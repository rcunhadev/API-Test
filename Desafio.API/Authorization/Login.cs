using Desafio.API.Models;
using System;

namespace Desafio.API
{
    public class Login : IDisposable
    {
        public bool SignIn(LoginDto request)
        {            
            if (request.Login == "apitest" 
                && request.Password == "@R3n470@#*@")
                return true;

            return false;
        }

        public void Dispose()
        {
        }
    }
}
