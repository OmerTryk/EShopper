﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopper.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand
    {
        public int Id { get; set; }

        public RemoveOrderDetailCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
