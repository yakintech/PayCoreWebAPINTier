using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.DTO.Models.Auth
{
    public class RegisterRequestDto
    {

        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
