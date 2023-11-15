﻿using PayCore.DTO.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.DTO.Models
{
    public class CreateCategoryResponseDto : BaseDto
    {
        public string Name { get; set; }
        public DateTime AddDate { get; set; }
    }
}
