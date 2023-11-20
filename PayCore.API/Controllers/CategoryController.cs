using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayCore.API.Models.Enums;
using PayCore.API.Models.Filters;
using PayCore.BLL.Services;
using PayCore.DAL.ORM;
using PayCore.DAL.ORM.Context;
using PayCore.DTO.Models;
using PayCore.DTO.Models.Category.Response;

namespace PayCore.API.Controllers
{

    [Authorize]
    public class CategoryController : BaseController
    {

        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public IActionResult Create(CreateCategoryRequestDto model)
        {
            Category category= new Category();
            category.Name = model.Name;

            _unitOfWork.categoryRepository.Create(category);
            _unitOfWork.Commit();

            var response = new CreateCategoryResponseDto()
            {
                Id = category.Id,
                Name = category.Name,
                AddDate = category.AddDate
            };

            return StatusCode(StatusCodes.Status201Created, response);
        }


        [HttpGet]
        [RoleFilter(EnumRoles.Admin)]

        public IActionResult GetAll()
        {
            //var response = _unitOfWork.categoryRepository.GetAll();
            var response2 = _unitOfWork.categoryRepository
                .GetAll()
                .Select(x => new GetAllCategoryResponseDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    AddDate = x.AddDate
                }).ToList();

            return Ok(response2);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var category = _unitOfWork.categoryRepository.GetById(id);

            if(category == null)
            {
                return NotFound();
            }
            else
            {
                var response = new GetByIdCategoryResponseDto();
                response.Id = category.Id;
                response.Name = category.Name;
                response.AddDate = category.AddDate;

                return Ok(category);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _unitOfWork.categoryRepository.Delete(id);
            _unitOfWork.Commit();

            return Ok("Deleted");
        }
       
    }
}


//SELECT[c].[Id], [c].[Name], [c].[AddDate]
//FROM[Categories] AS[c]
//WHERE[c].[IsDeleted] = CAST(0 AS bit)


//SELECT[c].[Id], [c].[AddDate], [c].[DeletedDate], [c].[IsDeleted], [c].[ModifiedDate], [c].[Name]
//FROM[Categories] AS[c]
//WHERE[c].[IsDeleted] = CAST(0 AS bit)