using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Shipping.DtoLayer.Dtos.CargoCustomerDtos;
using EShopper.Shipping.EntityLayer.Domain;

namespace EShopper.Shipping.MappingLayer.Mapping.CargoCustomerMapping
{
    public class CargoCustomerMapper : Profile
    {
        public CargoCustomerMapper()
        {
            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, UpdateCargoCustomerDto>().ReverseMap();
        }
    }
}
