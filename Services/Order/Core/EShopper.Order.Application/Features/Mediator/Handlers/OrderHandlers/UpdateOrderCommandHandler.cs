using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EShopper.Order.Application.Features.Mediator.Commands.OrderCommands;
using EShopper.Order.Application.Interfaces;
using EShopper.Order.Domain.Entities;
using MediatR;

namespace EShopper.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IRepository<Domain.Entities.Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var values = await _repository.GetByIdAsync(request.OrderId);
                if (values == null)
                    throw new KeyNotFoundException($"Sipariş bulunamadı. ID: {request.OrderId}");
                _mapper.Map(request, values);
                await _repository.UpdateAsync(values);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Sipariş getirilirken bir hata oluştu.", ex);
            }
        }
    }
}
