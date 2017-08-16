using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcUI.Models;
using Task.Entities;

namespace MvcUI.Infrastructure.Mappers
{
    public static class MvcMappers
    {
        public static MvcProduct ToMvcProduct(this Product productEntity)
        {
            return new MvcProduct
            {
                Title = productEntity.Title,
                Description = productEntity.Description,
                Price = productEntity.Price
            };
        }

        public static Product ToEntityProduct(this MvcProduct mvcProduct)
        {
            return new Product
            {
                Title = mvcProduct.Title,
                Description = mvcProduct.Description,
                Price = mvcProduct.Price
            };
        }
    }
}