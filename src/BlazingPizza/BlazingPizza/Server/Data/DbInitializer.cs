using BlazingPizza.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PizzaContext context)
        {
            if (context.Specials.Any())
            {
                return;
            }
            var toppings = new Topping[]
            {
                new Topping() { Name = "Extra cheese", Price = 2.50m },
                new Topping() { Name = "American bacon", Price = 2.99m },
                new Topping() { Name = "British bacon", Price = 2.99m },
                new Topping() { Name = "Canadian bacon", Price = 2.99m },
                new Topping() { Name = "Tea and crumpets", Price = 5.00m },
                new Topping() { Name = "Fresh-baked scones", Price = 4.50m },
                new Topping() { Name = "Bell peppers", Price = 1.00m },
                new Topping() { Name = "Onions", Price = 1.00m },
                new Topping() { Name = "Mushrooms", Price = 1.00m },
                new Topping() { Name = "Pepperoni", Price = 1.00m },
                new Topping() { Name = "Duck sausage", Price = 3.20m },
                new Topping() { Name = "Venison meatballs", Price = 2.50m },
                new Topping() { Name = "Served on a silver platter", Price = 250.99m },
                new Topping() { Name = "Lobster on top", Price = 64.50m },
                new Topping() { Name = "Sturgeon caviar", Price = 101.75m },
                new Topping() { Name = "Artichoke hearts", Price = 3.40m },
                new Topping() { Name = "Fresh tomatos", Price = 1.50m },
                new Topping() { Name = "Basil", Price = 1.50m },
                new Topping() { Name = "Steak (medium-rare)", Price = 8.50m },
                new Topping() { Name = "Blazing hot peppers", Price = 4.20m },
                new Topping() { Name = "Buffalo chicken", Price = 5.00m },
                new Topping() { Name = "Blue cheese", Price = 2.50m }
            };

            var specials = new PizzaSpecial[]
            {
                new PizzaSpecial() { Name = "Basic Cheese Pizza", BasePrice = 9.99m,
                    ImageUrl = "img/pizzas/cheese.jpg",
                    Description = "It's cheesy and delicious. Why wouldn't you want one?",
                },
                new PizzaSpecial() { Id = 2, Name = "The Baconatorizor", BasePrice = 11.99m,
                    ImageUrl = "img/pizzas/bacon.jpg",
                    Description = "It has EVERY kind of bacon",
                },
                new PizzaSpecial() { Id = 3, Name = "Classic pepperoni", BasePrice = 10.50m,
                    ImageUrl = "img/pizzas/pepperoni.jpg",
                    Description = "It's the pizza you grew up with, but Blazing hot!",
                },
                new PizzaSpecial() {
                    Id = 4, Name = "Buffalo chicken", BasePrice = 12.75m,
                    ImageUrl = "img/pizzas/meaty.jpg",
                    Description = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                },
                new PizzaSpecial() { Id = 5, Name = "Mushroom Lovers", BasePrice = 11.00m,
                    ImageUrl = "img/pizzas/mushroom.jpg",
                    Description = "It has mushrooms. Isn't that obvious?",
                },
                new PizzaSpecial() { Id = 6, Name = "The Brit", BasePrice = 10.25m,
                    ImageUrl = "img/pizzas/brit.jpg",
                    Description = "When in London...",
                },
                new PizzaSpecial() { Id = 7, Name = "Veggie Delight", BasePrice = 11.50m,
                    ImageUrl = "img/pizzas/salad.jpg",
                    Description = "It's like salad, but on a pizza",
                },
                new PizzaSpecial() { Id = 8, Name = "Margherita", BasePrice = 9.99m,
                    ImageUrl = "img/pizzas/margherita.jpg",
                    Description = "Traditional Italian pizza with tomatoes and basil",
                },
            };

            context.Toppings.AddRange(toppings);
            context.Specials.AddRange(specials);
            context.SaveChanges();
        }
    }
}
