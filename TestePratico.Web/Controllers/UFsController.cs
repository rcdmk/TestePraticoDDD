using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using TestePratico.Domain.Entities;
using TestePratico.Web.ViewModels;
using TestePratico.Web.WCF.UFAppService;

namespace TestePratico.Web.Controllers
{
    public class UFsController : Controller
    {
		private readonly IAppServiceBaseOf_UF ufApp;

		public UFsController(IAppServiceBaseOf_UF ufApp)
		{
			this.ufApp = ufApp;
		}

       // GET: UFs
        public ActionResult Index()
        {
			var ufs = Mapper.Map<IEnumerable<UFViewModel>>(ufApp.GetAll());

			return View(ufs);
		}

        // GET: UFs/Details/5
        public ActionResult Details(int id)
        {
			var uf = getViewModelById(id);

			if (uf != null)
			{
				return View(uf);
			}
			else
			{
				return new HttpNotFoundResult();
			}
		}

        // GET: UFs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UFs/Create
        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(UFViewModel uf)
        {
			if (ModelState.IsValid)
			{
				var ufDomain = Mapper.Map<UF>(uf);
				var result = ufApp.Add(ufDomain);

				if (result.IsValid)
				{
					return RedirectToAction("Index");
				}
				else
				{
					foreach(var error in result.Errors)
					{
						ModelState.AddModelError(error.Field, error.Message);
					}
				}
			}

			return View(uf);
		}

        // GET: UFs/Edit/5
        public ActionResult Edit(int id)
        {
			var uf = getViewModelById(id);

			if (uf != null)
			{
				return View(uf);
			}
			else
			{
				return new HttpNotFoundResult();
			}
		}

        // POST: UFs/Edit/5
        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(UFViewModel uf)
		{
			if (ModelState.IsValid)
			{
				var ufDomain = Mapper.Map<UF>(uf);
				var result = ufApp.Update(ufDomain);

				if (result.IsValid)
				{
					return RedirectToAction("Index");
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(error.Field, error.Message);
					}
				}
			}

			return View(uf);
		}

        // GET: UFs/Delete/5
        public ActionResult Delete(int id)
        {
			var uf = getViewModelById(id);

			if (uf != null)
			{
				ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);

				return View(uf);
			}
			else
			{
				return new HttpNotFoundResult();
			}
		}

        // POST: UFs/Delete/5
		[HttpPost]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var uf = ufApp.GetById(id);

			var result = ufApp.Remove(uf);
			if (result.IsValid)
			{
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Field, error.Message);
				}
			}

			TempData["ModelState"] = ModelState;

			return RedirectToAction("Delete", new { id = id, uniqueUri = Request.RequestContext.RouteData.Values["uniqueUri"] });
		}


		#region helpers

		UFViewModel getViewModelById(int id)
		{
			return Mapper.Map<UFViewModel>(ufApp.GetById(id));
		}

		#endregion
	}
}
