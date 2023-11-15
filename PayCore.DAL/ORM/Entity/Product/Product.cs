using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.DAL.ORM
{
    public class Product : BaseEntity
    {

        public string Name { get; set; } = "";

        public string Description { get; set; }

        public double UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public Guid CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
