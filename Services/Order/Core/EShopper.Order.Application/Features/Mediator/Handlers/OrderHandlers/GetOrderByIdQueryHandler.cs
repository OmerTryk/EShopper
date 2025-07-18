using AutoMapper;
using EShopper.Order.Application.Features.Mediator.Queries.OrderQueries;
using EShopper.Order.Application.Features.Mediator.Results.OrderResults;
using EShopper.Order.Application.Interfaces;
using MediatR;

namespace EShopper.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IRepository<Domain.Entities.Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var values = await _repository.GetByIdAsync(request.Id);
                if (values == null)
                    throw new KeyNotFoundException($"Sipariş bulunamadı. ID: {request.Id}");
                var result = _mapper.Map<GetOrderByIdQueryResult>(values);
                return result;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Sipariş getirilirken bir hata oluştu.", ex);
            }
        }
    }
}
