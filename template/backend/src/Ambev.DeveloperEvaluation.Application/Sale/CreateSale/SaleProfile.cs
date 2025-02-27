using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale
{
    public class SaleProfile: Profile
    {
        public SaleProfile()
        {
            CreateMap<Domain.Entities.Sale, SaleResult>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.Email));

        }
    }
}
