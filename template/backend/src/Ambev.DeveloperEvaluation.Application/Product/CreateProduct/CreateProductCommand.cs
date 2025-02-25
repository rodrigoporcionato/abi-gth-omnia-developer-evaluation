using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct
{
   public class CreateProductCommand : IRequest<CreateProductResult>
    {

        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string category { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public int RatingCount { get; set; }

    }
}
