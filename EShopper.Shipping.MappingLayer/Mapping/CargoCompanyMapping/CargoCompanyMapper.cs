using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Shipping.DtoLayer.Dtos.CargoCompanyDtos;
using EShopper.Shipping.EntityLayer.Domain;

namespace EShopper.Shipping.MappingLayer.Mapping.CargoCompanyMapping
{
    public class CargoCompanyMapper : Profile
    {
        public CargoCompanyMapper()
        {
            CreateMap<CargoCompany,CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany,UpdateCargoCompanyDto>().ReverseMap();
        }
    }
}
