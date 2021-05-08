using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectECommerce.Models
{
    public class LoginViewModel
    {
        public string ErrorMessage { get; set; }
        public User UserDetails { get; set; }
    }
}
