using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.DTO.Models
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public double UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public Guid CategoryId { get; set; }
    }
}
