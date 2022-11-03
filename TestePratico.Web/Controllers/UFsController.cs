using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TestePratico.Domain.Entities;
using TestePratico.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestePratico.Application.Interfaces;
using System.Collections.Generic;

namespace TestePratico.Web.Controllers
{
    public class UFsController : Controller
    {
        private readonly IUFAppService ufApp;
        private readonly IMapper Mapper;

        public UFsController(IMapper mapper, IUFAppService ufApp)
        {
            this.Mapper = mapper;
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
                return NotFound();
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
                    ufApp.SaveChanges();

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
                return NotFound();
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
                    ufApp.SaveChanges();
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
                return View(uf);
            }

            return NotFound();
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
                ufApp.SaveChanges();
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

            return RedirectToAction("Delete", new { id = id, uniqueUri = Request.HttpContext.GetRouteData().Values["uniqueUri"] });
        }


        #region helpers

        UFViewModel getViewModelById(int id)
        {
            return Mapper.Map<UFViewModel>(ufApp.GetById(id));
        }

        #endregion
    }
}
