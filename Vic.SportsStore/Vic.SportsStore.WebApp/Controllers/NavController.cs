﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;

namespace Vic.SportsStore.WebApp.Controllers
{
	public class NavController : Controller
	{
		private IProductsRepository repository;
		public NavController(IProductsRepository repo) { repository = repo; }
		public PartialViewResult Menu(string category = null)
		{
			ViewBag.SelectedCategory = category;
			IEnumerable<string> categories = repository
			.Products
			.Select(x => x.Category)
			.Distinct()
			.OrderBy(x => x);
			return PartialView("FlexMenu", categories);
		}
	}
}