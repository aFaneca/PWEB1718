using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho.Models
{
       public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}