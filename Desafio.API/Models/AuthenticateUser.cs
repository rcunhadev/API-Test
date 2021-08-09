using System;

namespace Desafio.API
{
    public class AuthenticateUser
    {
       
        public string Name { get; set; }
        public bool IsAuth { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        
    }
}
