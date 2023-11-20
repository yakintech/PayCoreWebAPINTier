using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PayCore.API.Models.Enums;
using PayCore.BLL.Services.Auth;
using System.Security.Claims;

namespace PayCore.API.Models.Filters
{
    public class RoleFilter :AuthorizeAttribute, IAuthorizationFilter
    {
        int role;

        public RoleFilter(EnumRoles roleNumber)
        {
            this.role = Convert.ToInt32(roleNumber);
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           var emailClaim = context.HttpContext.User.Claims.FirstOrDefault(q => q.Type == ClaimTypes.Email);

            if (emailClaim != null)
            {
                //db ye bakip bu userda role olup olmadigina bakacagim
                var roleCheck = RoleService.RoleCheck(emailClaim.Value, role);

                if (!roleCheck)
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Result = new UnauthorizedResult();


                }
            }
        }
    }
}
