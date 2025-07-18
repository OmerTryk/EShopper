using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using EShopper.Order.Application.Interfaces;
using EShopper.Order.Domain.Entities;

namespace EShopper.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;
        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            try
            {
                var values = _mapper.Map<OrderDetail>(command);
                await _repository.CreateAsync(values);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Sipariş detaylar oluşturulurken bir hata oluştu.", ex);
            }
        }
    }
}
