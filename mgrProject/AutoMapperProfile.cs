using AutoMapper;
using Domain.Entity;
using Domain.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderProductDTO, OrderProduct>();
            CreateMap<OrderStatusDTO, OrderStatus>();
            CreateMap<PaymentDetailDTO, PaymentDetail>();
            CreateMap<ProductDTO, Product>();
            CreateMap<ShipmentAdressDTO, ShipmentAdress>();
            CreateMap<ShipmentDetailDTO, ShipmentDetail>();
            CreateMap<ShoppingCartDTO, ShoppingCart>();
            CreateMap<UserDTO, User>();
            CreateMap<CartDTO, Cart>();
        }

    }
}
