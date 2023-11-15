using AutoMapper;
using PayCore.DAL.ORM;
using PayCore.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.Mapping
{
    public class CreateProductRequestProfile : Profile
    {
        public CreateProductRequestProfile()
        {
            CreateMap<CreateProductRequestDto, Product>()
                .AfterMap((_, dest) =>
                {
                    dest.UnitPrice = 500;
                });

        }
    }
}
