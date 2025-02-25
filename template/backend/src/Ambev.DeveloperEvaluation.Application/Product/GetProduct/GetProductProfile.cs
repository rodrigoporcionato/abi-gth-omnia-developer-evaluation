using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct
{
   public class GetProductProfile: Profile
    {
        public GetProductProfile()
        {
            CreateMap<Domain.Entities.Product, GetProductResult>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
           .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));




        }

    }
}
