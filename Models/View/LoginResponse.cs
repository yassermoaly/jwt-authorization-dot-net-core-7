using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.View
{
    public class LoginResponse
    {
        public string? Token { get; set; }
        public bool IsSucceeded { get; set; }
        public static LoginResponse CreateSuccess(string Token)
        {
            return new LoginResponse()
            {
                IsSucceeded = true,
                Token = Token
            };
        }
        public static LoginResponse CreateFailed()
        {
            return new LoginResponse()
            {
                IsSucceeded = false
            };
        }
    }
}
