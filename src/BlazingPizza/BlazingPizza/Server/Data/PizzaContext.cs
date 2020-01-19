using BlazingPizza.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza.Server.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<PizzaSpecial> Specials { get; set; }

        public DbSet<Topping> Toppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring a many-to-many special -> topping relationship that is friendly for serialisation
            modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });
            modelBuilder.Entity<PizzaTopping>().HasOne<Pizza>().WithMany(ps => ps.Toppings);
            modelBuilder.Entity<PizzaTopping>().HasOne(pst => pst.Topping).WithMany();

            // Inline the Lat-Long pairs in Order rather than having a FK to another table
            modelBuilder.Entity<Order>().OwnsOne(o => o.DeliveryLocation);
        }

    }
}
