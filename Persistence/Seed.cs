using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
      public static async Task SeedData(DataContext context)
        {
            if (context.Product.Any()) return;

            var product = new List<Product>
            {
              new Product
              {
                  Id=Guid.NewGuid(),
                  Title="Mobile"
              },
              new Product
              {
                  Id=Guid.NewGuid(),
                  Title="Computer"
              },
              new Product
              {
                  Id=Guid.NewGuid(),
                  Title="TV"
              },
              new Product
              {
                  Id=Guid.NewGuid(),
                  Title="Radio"
              },
              new Product
              {
                  Id=Guid.NewGuid(),
                  Title="Laptop"
              }
            };
            await context.Product.AddRangeAsync(product);
            await context.SaveChangesAsync();
        }
    }
}
