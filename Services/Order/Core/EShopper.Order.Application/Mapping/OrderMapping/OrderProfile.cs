using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Order.Application.Features.Mediator.Commands.OrderCommands;
using EShopper.Order.Application.Features.Mediator.Results.OrderResults;

namespace EShopper.Order.Application.Mapping.OrderMapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Domain.Entities.Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Domain.Entities.Order, UpdateOrderCommand>().ReverseMap();
            CreateMap<Domain.Entities.Order, GetOrderQueryResult>().ReverseMap();
            CreateMap<Domain.Entities.Order, GetOrderByIdQueryResult>().ReverseMap();
        }
    }
}
