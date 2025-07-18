using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopper.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using EShopper.Order.Application.Interfaces;
using EShopper.Order.Domain.Entities;

namespace EShopper.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand command)
        {
            try
            {
                var values = await _repository.GetByIdAsync(command.Id);
                await _repository.DeleteAsync(values);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Sipariş detaylar silinirken bir hata oluştu.", ex);
            }
        }

    }
}
