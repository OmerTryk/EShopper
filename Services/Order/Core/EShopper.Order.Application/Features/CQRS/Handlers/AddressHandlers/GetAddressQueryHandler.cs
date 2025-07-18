using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Order.Application.Features.CQRS.Results.AddressResults;
using EShopper.Order.Application.Interfaces;
using EShopper.Order.Domain.Entities;

namespace EShopper.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAddressByIdQueryResult>> Handle()
        {
            try
            {
                var values = await _repository.GetAllAsync();
                return _mapper.Map<List<GetAddressByIdQueryResult>>(values);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Tüm adres bilgileri getirilirken bir hata oluştu.", ex);
            }
        }

    }
}
