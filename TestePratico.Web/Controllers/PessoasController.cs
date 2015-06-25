﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using TestePratico.Web.ViewModels;
using TestePratico.Web.WCF.PessoaAppService;
using TestePratico.Web.WCF.UFAppService;

namespace TestePratico.Web.Controllers
{
	public class PessoasController : Controller
	{
		private readonly IAppServiceBaseOf_Pessoa pessoaService;
		private readonly IAppServiceBaseOf_UF ufService;

		public PessoasController(IAppServiceBaseOf_Pessoa pessoaService, IAppServiceBaseOf_UF ufService)
		{
			this.pessoaService = pessoaService;
			this.ufService = ufService;
		}

		// GET: Pessoas
		public ActionResult Index()
		{
			var pessoas = Mapper.Map<IEnumerable<PessoaViewModel>>(pessoaService.GetAll());

			return View(pessoas);
		}

		// GET: Pessoas/Details/5
		public ActionResult Details(int id)
		{
			var pessoa = getViewModelById(id);

			if (pessoa != null)
			{
				return View(pessoa);
			}
			else
			{
				return new HttpNotFoundResult();
			}
		}

		// GET: Pessoas/Create
		public ActionResult Create()
		{
			ViewBag.IdUF = getUFList();
			return View();
		}

		// POST: Pessoas/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(PessoaViewModel pessoa)
		{
			if (ModelState.IsValid)
			{
				var pessoaDomain = Mapper.Map<Pessoa>(pessoa);
				var result = pessoaService.Add(pessoaDomain);

				if (result.IsValid)
				{
					return RedirectToAction("Index");
				}
				else
				{
					foreach (var erro in result.Errors)
					{
						ModelState.AddModelError(erro.Field, erro.Message);
					}
				}
			}

			ViewBag.IdUF = getUFList();
			return View(pessoa);
		}

		// GET: Pessoas/Edit/5
		public ActionResult Edit(int id)
		{
			var pessoa = getViewModelById(id);
			ViewBag.IdUF = getUFList(pessoa.IdUF);


			if (pessoa != null)
			{
				return View(pessoa);
			}
			else
			{
				return new HttpNotFoundResult();
			}
		}

		// POST: Pessoas/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(PessoaViewModel pessoa)
		{
			if (ModelState.IsValid)
			{
				var pessoaDomain = Mapper.Map<Pessoa>(pessoa);
				var result = pessoaService.Update(pessoaDomain);

				if (result.IsValid)
				{
					return RedirectToAction("Index");
				}
				else
				{
					foreach (var erro in result.Errors)
					{
						ModelState.AddModelError(erro.Field, erro.Message);
					}
				}
			}

			ViewBag.IdUF = getUFList(pessoa.IdUF);
			return View(pessoa);
		}

		// GET: Pessoas/Delete/5
		public ActionResult Delete(int id)
		{
			var pessoa = getViewModelById(id);

			if (pessoa != null)
			{
				ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);

				return View(pessoa);
			}
			else
			{
				return new HttpNotFoundResult();
			}
		}

		// POST: Pessoas/Delete/5
		[HttpPost]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var pessoa = pessoaService.GetById(id);

			var result = pessoaService.Remove(pessoa);

			if (result.IsValid)
			{
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var erro in result.Errors)
				{
					ModelState.AddModelError(erro.Field, erro.Message);
				}
			}

			TempData["ModelState"] = ModelState;

			return RedirectToAction("Delete", new { id = id });
		}

		#region helpers

		PessoaViewModel getViewModelById(int id)
		{
			return Mapper.Map<PessoaViewModel>(pessoaService.GetById(id));
		}

		SelectList getUFList(int? IdSelectedUF = null)
		{
			return new SelectList(Mapper.Map<IEnumerable<UFViewModel>>(ufService.GetAll()), "IdUF", "Nome", IdSelectedUF);
		}

		#endregion
	}
}
