using EShopper.Order.Application.Features.Mediator.Commands.OrderCommands;
using EShopper.Order.Application.Interfaces;
using MediatR;

namespace EShopper.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;

        public RemoveOrderCommandHandler(IRepository<Domain.Entities.Order> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var values = await _repository.GetByIdAsync(request.Id);
                await _repository.DeleteAsync(values);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Sipariş getirilirken bir hata oluştu.", ex);
            }
        }
    }
}
