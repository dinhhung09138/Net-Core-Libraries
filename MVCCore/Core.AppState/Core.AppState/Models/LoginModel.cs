using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.AppState.Models
{
    public class LoginModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string RequestPath { get; set; }
    }
}
