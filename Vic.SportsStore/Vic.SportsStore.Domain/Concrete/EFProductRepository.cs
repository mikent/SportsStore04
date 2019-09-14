using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.Domain.Concrete
{
	public class EFProductRepository : IProductsRepository
	{
		//private EFDbContext context = new EFDbContext();
		public EFDbContext Context { get; set; }
		public IEnumerable<Product> Products { get { return Context.Products; } }
	}
}
