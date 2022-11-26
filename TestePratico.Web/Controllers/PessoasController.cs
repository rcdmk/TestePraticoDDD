using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TestePratico.Domain.Entities;
using TestePratico.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestePratico.Application.Interfaces;
using System.Collections.Generic;

namespace TestePratico.Web.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaAppService pessoaService;
        private readonly IUFAppService ufService;
        private readonly IMapper Mapper;

        public PessoasController(IMapper mapper, IPessoaAppService pessoaService, IUFAppService ufService)
        {
            this.Mapper = mapper;
            this.pessoaService = pessoaService;
            this.ufService = ufService;
        }

        // GET: Pessoas
        public ActionResult Index()
        {
            var pessoas = Mapper.Map<IEnumerable<PersonViewModel>>(pessoaService.GetAll());

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
                return NotFound();
            }
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            var pessoa = new PersonViewModel();
            pessoa.UFs = getUFList();

            return View(pessoa);
        }

        // POST: Pessoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonViewModel pessoa)
        {
            if (ModelState.IsValid)
            {
                var pessoaDomain = Mapper.Map<Person>(pessoa);
                var result = pessoaService.Add(pessoaDomain);

                if (result.IsValid)
                {
                    pessoaService.SaveChanges();
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

            pessoa.UFs = getUFList();
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = getViewModelById(id);

            if (pessoa != null)
            {
                pessoa.UFs = getUFList();
                return View(pessoa);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Pessoas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonViewModel pessoa)
        {
            if (ModelState.IsValid)
            {
                var existingPessoa = pessoaService.GetById(pessoa.PersonId);
                if (existingPessoa == null) return NotFound();

                var pessoaDomain = Mapper.Map(pessoa, existingPessoa);
                var result = pessoaService.Update(pessoaDomain);

                if (result.IsValid)
                {
                    try
                    {
                        pessoaService.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
                else
                {
                    foreach (var erro in result.Errors)
                    {
                        ModelState.AddModelError(erro.Field, erro.Message);
                    }
                }
            }

            pessoa.UFs = getUFList();
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int id)
        {
            var pessoa = getViewModelById(id);

            if (pessoa != null)
            {
                return View(pessoa);
            }

            return NotFound();
        }

        // POST: Pessoas/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pessoa = pessoaService.GetById(id);

            if (pessoa == null) return NotFound();

            var result = pessoaService.Remove(pessoa);

            if (result.IsValid)
            {
                pessoaService.SaveChanges();
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

        PersonViewModel getViewModelById(int id)
        {
            return Mapper.Map<PersonViewModel>(pessoaService.GetById(id));
        }

        IList<SelectListItem> getUFList()
        {
            var ufs = ufService.GetAll();
            return Mapper.Map<IList<SelectListItem>>(ufs);
        }

        #endregion
    }
}
