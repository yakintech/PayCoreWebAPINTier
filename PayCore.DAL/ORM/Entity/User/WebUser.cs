using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.DAL.ORM.Entity.User
{
    public class WebUser : BaseEntity
    {
        public string EMail { get; set; }
        public string Password { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }

        public string Roles { get; set; } //1,2,5,3,7
    }
}
