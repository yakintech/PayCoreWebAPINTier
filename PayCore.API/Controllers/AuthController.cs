using Microsoft.AspNetCore.Mvc;
using PayCore.API.Models.Auth;
using PayCore.BLL.Services;
using PayCore.DAL.ORM.Entity.User;
using PayCore.DTO.Models;
using PayCore.DTO.Models.Auth;

namespace PayCore.API.Controllers
{
    public class AuthController : BaseController
    {
        private IUnitOfWork _unitOfWork;
        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Login(LoginRequestDto model)
        {
            var userControl = _unitOfWork.webUserRepository.Any(q => q.EMail.ToLower() == model.EMail.ToLower() && q.Password == model.Password);

            if (userControl)
            {
                var paycoreTokenHandler = new PayCoreTokenHandler();

                var token = paycoreTokenHandler.CreateAccessToken(model.EMail);

                // dbdeki kullanicinin refresh token i updatge ediyorum
                var webuser = _unitOfWork.webUserRepository.FirstOrDefault(x => x.EMail == model.EMail);

                webuser.RefreshToken = token.RefreshToken;
                webuser.RefreshTokenExpireDate = token.ExpireDate.AddMinutes(10);

                _unitOfWork.Commit();

                return Ok(token);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("refreshToken")]
        public IActionResult RefreshToken(RefreshTokenRequestDto model)
        {
            WebUser webUser = _unitOfWork.webUserRepository.FirstOrDefault(q => q.RefreshToken == model.RefreshToken);

            if (webUser != null)
            {
                if(webUser.RefreshTokenExpireDate > DateTime.Now)
                {
                    var paycoreTokenHandler = new PayCoreTokenHandler();
                    var token = paycoreTokenHandler.CreateAccessToken(webUser.EMail);

                    webUser.RefreshToken = token.RefreshToken;
                    webUser.RefreshTokenExpireDate = token.ExpireDate.AddMinutes(10);

                    token.RefreshTokenExpireDate = webUser.RefreshTokenExpireDate;
                    _unitOfWork.Commit();

                    return Ok(token) ;
                }
                else
                {
                    return BadRequest("Token suresi doldu");
                }
            }
            else
            {
                return NotFound();
            }

        }
    }
}
