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

		public ViewResult List()
		{
			//return View(repository.Products);
			return View(ProductsRepository.Products);
		}
	}
}