using FluentValidation;
using PayCore.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.Validation.Models.Category
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequestDto>
    {
        public CreateCategoryRequestValidator() {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field is required!");

        }
    }
}
