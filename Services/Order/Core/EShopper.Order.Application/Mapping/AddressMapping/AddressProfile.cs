using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Order.Application.Features.CQRS.Commands.AddressCommands;
using EShopper.Order.Application.Features.CQRS.Results.AddressResults;
using EShopper.Order.Domain.Entities;

namespace EShopper.Order.Application.Mapping.AddressMapping
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address,GetAddressByIdQueryResult>().ReverseMap();
            CreateMap<Address,GetAddressQueryResult>().ReverseMap();
            CreateMap<Address,UpdateAddressCommand>().ReverseMap();
            CreateMap<Address,CreateAddressCommand>().ReverseMap();
        }
    }
}
