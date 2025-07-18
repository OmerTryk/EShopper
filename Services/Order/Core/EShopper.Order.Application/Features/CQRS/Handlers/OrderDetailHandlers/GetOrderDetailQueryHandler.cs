using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Order.Application.Features.CQRS.Results.OrderDetailResults;
using EShopper.Order.Application.Interfaces;
using EShopper.Order.Domain.Entities;

namespace EShopper.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;
        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            try
            {
                var values = await _repository.GetAllAsync();
                var result = _mapper.Map<List<GetOrderDetailQueryResult>>(values);
                return result;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Tüm sipariş detaylar getirilirken bir hata oluştu.", ex);
            }
        }

    }
}
