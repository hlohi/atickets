﻿using atickets.Data.Base;
using atickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atickets.Data.Services
{
    public class ProducersService: EntityBaseRepository<Producer>,IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {

        }
    }
}
