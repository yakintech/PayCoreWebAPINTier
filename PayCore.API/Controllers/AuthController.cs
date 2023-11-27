using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayCore.API.Models.Auth;
using PayCore.BLL.Services;
using PayCore.DAL.ORM.Context;
using PayCore.DAL.ORM.Entity.User;
using PayCore.DTO.Models;
using PayCore.DTO.Models.Auth;

namespace PayCore.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly UserManager<WebUser> _userManager;
        private IUnitOfWork _unitOfWork;
        public AuthController(
            UserManager<WebUser> userManager,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequestDto model)
        {
            var userExist = await _userManager.FindByEmailAsync(model.EMail);

            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "User already exists!");
            }
            else
            {

                var paycoreTokenHandler = new PayCoreTokenHandler();

                var token = paycoreTokenHandler.CreateAccessToken(model.EMail);

              

                WebUser user = new()
                {
                    Email = model.EMail,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.EMail,
                    RefreshToken = token.RefreshToken,
                    RefreshTokenExpireDate = token.ExpireDate.AddMinutes(10)

            };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError, "User creation failed! Please check user details and try again.");

                return Ok(token);

            }
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.EMail);


            var userControl = await _userManager.CheckPasswordAsync(user, model.Password);
                

            if (userControl)
            {
                var paycoreTokenHandler = new PayCoreTokenHandler();

                var token = paycoreTokenHandler.CreateAccessToken(model.EMail);

                // dbdeki kullanicinin refresh token i update ediyorum


                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.ExpireDate.AddMinutes(10);


                await _userManager.UpdateAsync(user);

                return Ok(token);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("refreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDto model)
        {
            var webUser = await _userManager.FindByEmailAsync(model.EMail);

            

            if (webUser != null)
            {
                if (webUser.RefreshToken == model.RefreshToken)
                {
                    if (webUser.RefreshTokenExpireDate > DateTime.Now)
                    {
                        var paycoreTokenHandler = new PayCoreTokenHandler();
                        var token = paycoreTokenHandler.CreateAccessToken(webUser.Email);

                        webUser.RefreshToken = token.RefreshToken;
                        webUser.RefreshTokenExpireDate = token.ExpireDate.AddMinutes(10);

                        token.RefreshTokenExpireDate = webUser.RefreshTokenExpireDate;

                        await _userManager.UpdateAsync(webUser);

                        return Ok(token);
                    }
                    else
                    {
                        return BadRequest("Token suresi doldu");
                    }
                }
                else
                {
                    return BadRequest();
                }
    
            }
            else
            {
                return NotFound();
            }

        }
    }
}
