using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Shipping.DtoLayer.Dtos.CargoOperationDtos;
using EShopper.Shipping.EntityLayer.Domain;

namespace EShopper.Shipping.MappingLayer.Mapping.CargoOperationMapping
{
    public class CargoOperationMapper : Profile
    {
        public CargoOperationMapper()
        {
            CreateMap<CargoOperation,CreateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation,UpdateCargoOperationDto>().ReverseMap();
        }
    }
}
