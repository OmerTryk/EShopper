using AutoMapper;
using EShopper.Order.Application.Features.CQRS.Commands.AddressCommands;
using EShopper.Order.Application.Features.Mediator.Commands.OrderCommands;
using EShopper.Order.Application.Interfaces;
using MediatR;

namespace EShopper.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IRepository<Domain.Entities.Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _mapper.Map<Domain.Entities.Order>(request);
                await _repository.CreateAsync(result);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Sipariş oluşturulurken bir hata oluştu.", ex);
            }
        }
    }
}
