using System;
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
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAddressCommand command)
        {
            try
            {
                await _repository.CreateAsync(_mapper.Map<Address>(command));

            }
            catch (Exception ex)
            {

                throw new ApplicationException("Adres oluşturulurken bir hata oluştu.", ex);
            }
        }

    }
}
