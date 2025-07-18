using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopper.Order.Application.Features.Mediator.Results.OrderResults;
using MediatR;

namespace EShopper.Order.Application.Features.Mediator.Queries.OrderQueries
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
