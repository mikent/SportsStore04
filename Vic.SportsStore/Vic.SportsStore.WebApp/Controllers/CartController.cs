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
		public RedirectToRouteResult AddToCart(int productId, string returnUrl)
		{
			Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				GetCart().AddItem(product, 1);
			}
			return RedirectToAction("Index", new { returnUrl });
		}
		public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
		{
			Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				GetCart().RemoveLine(product);
			}
			return RedirectToAction("Index", new { returnUrl });
		}
		private Cart GetCart()
		{
			Cart cart = (Cart)Session["Cart"];
			if (cart == null)
			{
				cart = new Cart();
				Session["Cart"] = cart;
			}
			return cart;
		}
		public System.Web.Mvc.ViewResult Index(string returnUrl)
		{
			return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
		}
	}
}