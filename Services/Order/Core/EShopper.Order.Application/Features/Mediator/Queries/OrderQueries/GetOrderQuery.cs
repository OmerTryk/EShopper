using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopper.Order.Application.Features.Mediator.Results.OrderResults;
using MediatR;

namespace EShopper.Order.Application.Features.Mediator.Queries.OrderQueries
{
    public class GetOrderQuery : IRequest<List<GetOrderQueryResult>>
    {
    }
}
