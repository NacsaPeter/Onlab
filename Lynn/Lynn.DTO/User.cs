using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DTO
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Points { get; set; }
    }
}
