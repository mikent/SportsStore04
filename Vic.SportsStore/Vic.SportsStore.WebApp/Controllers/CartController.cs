using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.WebApp.Models;


namespace Vic.SportsStore.WebApp.Controllers
{
	public class CartController : Controller
	{
		private IProductsRepository repository;
		public CartController(IProductsRepository repo) {
			repository = repo;
		}
		public ViewResult Index(Cart cart, string returnUrl)
		{
			return View(new CartIndexViewModel
			{
				ReturnUrl = returnUrl,
				Cart = cart
			});
		}
		public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
		{
			Product product = repository.Products
			.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				cart.AddItem(product, 1);
			}
			return RedirectToAction("Index", new { returnUrl });
		}
		public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
		{
			Product product = repository.Products
			.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				cart.RemoveLine(product);
			}
			return RedirectToAction("Index", new { returnUrl });
		}
	}
}