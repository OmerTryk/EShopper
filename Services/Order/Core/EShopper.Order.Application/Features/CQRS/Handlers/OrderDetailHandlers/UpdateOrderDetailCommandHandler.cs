using System;
using System.Collections;
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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            try
            {
                var values = await _repository.GetByIdAsync(command.OrderDetailId);
                if (values == null) throw new KeyNotFoundException($"Sipariş bulunamadı. ID: {command.OrderDetailId}");
                _mapper.Map(command, values);
                await _repository.UpdateAsync(values);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Sipariş detaylar güncellenirken bir hata oluştu.", ex);
            }
        }

    }
}
