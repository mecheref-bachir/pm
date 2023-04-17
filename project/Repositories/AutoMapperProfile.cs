using AutoMapper;
using project.Models.ProductModels.Domain;
using project.Models.ProductModels.Dto;

namespace project.Repositories
{
    public class AutoMapperProfile:Profile

    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductModel>();
        }
    }
}
