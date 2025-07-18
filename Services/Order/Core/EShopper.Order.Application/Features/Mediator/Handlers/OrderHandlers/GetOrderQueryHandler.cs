using AutoMapper;
using EShopper.Order.Application.Features.Mediator.Queries.OrderQueries;
using EShopper.Order.Application.Features.Mediator.Results.OrderResults;
using EShopper.Order.Application.Interfaces;
using MediatR;

namespace EShopper.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<GetOrderQueryResult>>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IRepository<Domain.Entities.Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderQueryResult>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var values = await _repository.GetAllAsync();
                var result = _mapper.Map<List<GetOrderQueryResult>>(values);
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Siparişler getirilirken bir hata oluştu.", ex);
            }
        }
    }
}

