using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.DAL.ORM.Entity.User
{
    public class WebUser : IdentityUser
    {

        public DateTime AddDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool IsDeleted { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }

        public string Roles { get; set; } //1,2,5,3,7
    }
}
