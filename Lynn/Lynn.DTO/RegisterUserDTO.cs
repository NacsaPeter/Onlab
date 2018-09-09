using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DTO
{
    public class RegisterUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Level { get; set; }
    }
}
