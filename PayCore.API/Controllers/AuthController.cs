using Microsoft.AspNetCore.Mvc;
using PayCore.API.Models.Auth;
using PayCore.BLL.Services;
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
            var userControl = _unitOfWork.webUserRepository.Any(q => q.EMail.ToLower() == model.EMail.ToLower());

            if (userControl)
            {
                var paycoreTokenHandler = new PayCoreTokenHandler();

                var token = paycoreTokenHandler.CreateAccessToken(model.EMail);

                return Ok(token);
            }
            else
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
