using System.Linq;
using AutoMapper;
using ProductShop.DTO.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, UserProductSoldDTO>()
                .ForMember(x=>x.ProductName, y=>y.MapFrom(z=>z.Name))
                .ForMember(x => x.BuyerFirstName,
                    y => y.MapFrom(x => x.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName,
                    y => y.MapFrom(z => z.Buyer.LastName));

            this.CreateMap<User, UserWithSoldProductDTO>()
                .ForMember(x => x.ListSoldProducts, 
                    y => y.MapFrom(z => z.ProductsSold.Where(p => p.Buyer != null)));
        }
    }
}
