using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopper.Order.Application.Features.CQRS.Commands.AddressCommands;
using EShopper.Order.Application.Interfaces;
using EShopper.Order.Domain.Entities;

namespace EShopper.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAddressCommand command)
        {
            try
            {
                var values = await _repository.GetByIdAsync(command.Id);
                if (values == null) throw new KeyNotFoundException($"Adres bulunamadı. ID: {command.Id}");
                await _repository.DeleteAsync(values);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Adres bilgileri silinirken bir hata oluştu.", ex);
            }
        }

    }
}
