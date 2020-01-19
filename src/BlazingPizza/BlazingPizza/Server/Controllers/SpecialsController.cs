using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Server.Data;
using BlazingPizza.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpecialsController : Controller
    {
        private readonly PizzaContext context;

        public SpecialsController(PizzaContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PizzaSpecial>> Get()
        {
            return await context.Specials
                .OrderByDescending(s => (float)s.BasePrice).ToListAsync();
        }
    }
}

