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
    public class ToppingsController : Controller
    {
        private readonly PizzaContext context;

        public ToppingsController(PizzaContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Topping>> Get()
        {
            return await context.Toppings.OrderBy(t => t.Name).ToListAsync();
        }
    }
}