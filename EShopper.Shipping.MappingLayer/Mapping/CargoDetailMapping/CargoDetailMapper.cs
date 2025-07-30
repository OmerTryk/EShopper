using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Shipping.DtoLayer.Dtos.CargoCustomerDtos;
using EShopper.Shipping.DtoLayer.Dtos.CargoDetailDtos;
using EShopper.Shipping.EntityLayer.Domain;

namespace EShopper.Shipping.MappingLayer.Mapping.CargoDetailMapping
{
    public class CargoDetailMapper : Profile
    {
        public CargoDetailMapper()
        {
            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();
        }
    }
}
