using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.WebApp.Models;

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
			ProductsListViewModel model = new ProductsListViewModel
			{ Products = ProductsRepository
			.Products
			.OrderBy(p => p.ProductId)
			.Skip((page - 1) * PageSize)
			.Take(PageSize),

			PagingInfo = new PagingInfo
			{ CurrentPage = page, ItemsPerPage = PageSize,
				TotalItems = ProductsRepository.Products.Count() } };
			return View(model);
		}

	}
}