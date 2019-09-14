using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
		public IProductsRepository ProductsRepository { get; set; }

		/*
		private IProductsRepository repository;

		public ProductController(IProductsRepository productsRepository)
		{
			this.repository = productsRepository;
		}
		*/

		public int PageSize = 2;

		public ViewResult List(int page = 1) {
			var ret = View(
				ProductsRepository
				.Products.OrderBy(p => p.ProductId)
				.Skip((page - 1) * PageSize)
				.Take(PageSize));
			return ret;
		}

	}
}