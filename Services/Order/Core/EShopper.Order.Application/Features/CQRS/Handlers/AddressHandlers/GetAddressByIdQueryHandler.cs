using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Order.Application.Features.CQRS.Queries.AddressQueries;
using EShopper.Order.Application.Features.CQRS.Results.AddressResults;
using EShopper.Order.Application.Interfaces;
using EShopper.Order.Domain.Entities;

namespace EShopper.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;
        public GetAddressByIdQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            try
            {
                var values = await _repository.GetByIdAsync(query.Id);
                if (values == null) throw new KeyNotFoundException($"Adres bulunamadı. ID: {query.Id}");
                var result = _mapper.Map<GetAddressByIdQueryResult>(values);
                return result;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Adres bilgileri getirilirken bir hata oluştu.", ex);
            }
        }

    }
}
