﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.DTO.Models
{
    public class RefreshTokenRequestDto
    {
        public string EMail { get; set; }
        public string RefreshToken { get; set; }
    }
}
