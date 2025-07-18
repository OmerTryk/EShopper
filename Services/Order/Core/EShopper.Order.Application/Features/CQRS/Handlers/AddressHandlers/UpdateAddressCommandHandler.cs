using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Order.Application.Features.CQRS.Commands.AddressCommands;
using EShopper.Order.Application.Interfaces;
using EShopper.Order.Domain.Entities;

namespace EShopper.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            try
            {
                var values = await _repository.GetByIdAsync(command.AddressId);
                if (values == null) throw new KeyNotFoundException($"Adres bulunamadı. ID: {command.AddressId}");
                _mapper.Map(command, values);
                await _repository.UpdateAsync(values);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Adres bilgileri güncellenirken bir hata oluştu.", ex);
            }
        }

    }
}
