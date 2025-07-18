using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using EShopper.Order.Application.Features.CQRS.Results.OrderDetailResults;
using EShopper.Order.Application.Interfaces;
using EShopper.Order.Domain.Entities;
using MediatR;

namespace EShopper.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOrderDetailQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            try
            {
                var values = await _repository.GetByIdAsync(query.Id);
                if (values == null) throw new KeyNotFoundException($"Sipariş bulunamadı. ID: {query.Id}");
                var result = _mapper.Map<GetOrderDetailQueryResult>(values);
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Sipariş detaylar getirilirken bir hata oluştu.", ex);
            }
        }

    }
}
