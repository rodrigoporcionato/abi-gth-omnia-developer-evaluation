using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SaleProfile
{
    public class SaleProfile: Profile
    {
        public SaleProfile()
        {
            CreateMap<Sale, SaleResult>();
        }
    }
}
