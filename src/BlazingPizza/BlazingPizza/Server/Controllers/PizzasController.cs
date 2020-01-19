using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PizzasController : Controller
    {
        private readonly PizzaContext context;

        public PizzasController(PizzaContext context)
        {
            this.context = context;
        }

    }
}