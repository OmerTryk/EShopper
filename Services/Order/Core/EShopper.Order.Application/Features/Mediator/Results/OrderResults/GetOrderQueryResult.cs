﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopper.Order.Application.Features.Mediator.Queries.OrderQueries;
using MediatR;

namespace EShopper.Order.Application.Features.Mediator.Results.OrderResults
{
    public class GetOrderQueryResult
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
