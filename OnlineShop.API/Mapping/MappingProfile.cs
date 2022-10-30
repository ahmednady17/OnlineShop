using AutoMapper;
using OnlineShop.API.ViewModels;
using OnlineShop.Domain.Models;

namespace OnlineShop.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductViewModel, Product>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();
        }

    }
}
