using Autofac;
using Autofac.Integration.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.WebApp
{
	public class IocConfig
	{
		public static void ConfigIoc()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(typeof(MvcApplication).Assembly)
				.PropertiesAutowired();
			

			Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
			mock.Setup(m => m.Products).Returns(new List<Product>
			{
				new Product { Name = "Football", Price = 25 },
				new Product { Name = "Surf board", Price = 179 },
				new Product { Name = "Running shoes", Price = 95 }
			});

			//builder.RegisterInstance<IProductsRepository>(mock.Object);
			builder.RegisterInstance<IProductsRepository>(new EFProductRepository())
							.PropertiesAutowired();

			builder.RegisterInstance<EFDbContext>(new EFDbContext())
							.PropertiesAutowired();

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}