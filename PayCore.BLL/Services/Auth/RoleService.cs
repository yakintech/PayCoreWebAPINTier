using PayCore.DAL.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.BLL.Services.Auth
{
    public class RoleService
    {

        public static bool RoleCheck(string email, int roleNumber)
        {
            var context = new PayCoreContext();

            var roleStatus = false;

            var roleControl = context.WebUsers.FirstOrDefault(q => q.IsDeleted == false && q.EMail == email);

            if (roleControl != null)
            {
                string[] roles = roleControl.Roles?.Split(';');

                foreach (var role in roles)
                {
                    if(role == roleNumber.ToString())
                    {
                        roleStatus = true;
                    }
                }
            }

            return roleStatus;
        }
    }
}
