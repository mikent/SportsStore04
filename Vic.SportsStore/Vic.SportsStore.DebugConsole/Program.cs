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
				for(int i = 0; i < 20; i++)
				{
					var product1 = new Product()
					{
						Name = $"apple_{i}",
						Price = i+1m,
						Description = $"this is fruit_{i}",
						Category = "food",
					};

					var product2 = new Product()
					{
						Name = $"book_{i}",
						Price = i + 1m,
						Description = $"this is book_{i}",
						Category = "book",
					};
					ctx.Products.Add(product1);
					ctx.Products.Add(product2);
				}


				ctx.SaveChanges();

			}

			Console.WriteLine("ok");
			Console.ReadKey();
		}
	}
}
