using atickets.Data.Base;
using atickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {

        public ActorsService(AppDbContext context) : base(context) { }
        
    }
}
