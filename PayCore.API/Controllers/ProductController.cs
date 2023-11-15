using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCore.BLL.Services;
using PayCore.DAL.ORM;
using PayCore.DTO.Models;

namespace PayCore.API.Controllers
{

    public class ProductController : BaseController
    {

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult Create(CreateProductRequestDto model)
        {
            var product = _mapper.Map<Product>(model);

            _unitOfWork.productRepository.Create(product);
            _unitOfWork.Commit();
         

            return Ok("");
        }

    }
}
