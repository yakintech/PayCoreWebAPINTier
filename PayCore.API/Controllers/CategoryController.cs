using Microsoft.AspNetCore.Mvc;
using PayCore.BLL.Services;
using PayCore.DAL.ORM;
using PayCore.DAL.ORM.Context;

namespace PayCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _unitOfWork.categoryRepository.GetAll();
            return Ok(result);  
        }
    }
}
