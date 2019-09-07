using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.DebugConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var ctx = new EFDbContext())
			{
				var product = new Product() {
					Name = "apple1",
					Price = 1.2m,
					Description = "fruit",
					Category = "food",
				};
				var c = ctx.Products.Add(product);
				ctx.SaveChanges();
				c.Name = "small apple";
				ctx.SaveChanges();
			}

			Console.WriteLine("ok");
			Console.ReadKey();
		}
	}
}
