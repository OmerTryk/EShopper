using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using EShopper.Order.Application.Features.CQRS.Results.OrderDetailResults;
using EShopper.Order.Domain.Entities;

namespace EShopper.Order.Application.Mapping.OrderDetailMapping
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, GetOrderDetailByIdQueryResult>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailQueryResult>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();
        }
    }
}
