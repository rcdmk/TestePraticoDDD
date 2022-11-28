using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TestePratico.Domain.Entities;
using TestePratico.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestePratico.Application.Interfaces;

namespace TestePratico.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonAppService personService;
        private readonly IUFAppService ufService;
        private readonly IMapper Mapper;

        public PeopleController(IMapper mapper, IPersonAppService personService, IUFAppService ufService)
        {
            this.Mapper = mapper;
            this.personService = personService;
            this.ufService = ufService;
        }

        // GET: People
        public ActionResult Index()
        {
            var people = Mapper.Map<IEnumerable<PersonViewModel>>(personService.GetAll());

            return View(people);
        }

        // GET: People/Details/5
        public ActionResult Details(int id)
        {
            var person = getViewModelById(id);

            if (person != null)
            {
                return View(person);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: People/Create
        public ActionResult Create()
        {
            var person = new PersonViewModel();
            person.UFs = getUFList();

            return View(person);
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                var personEntity = Mapper.Map<Person>(person);
                var result = personService.Add(personEntity);

                if (result.IsValid)
                {
                    personService.SaveChanges();
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

            person.UFs = getUFList();
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            var person = getViewModelById(id);

            if (person != null)
            {
                person.UFs = getUFList();
                return View(person);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                var existingPerson = personService.GetById(person.PersonId);
                if (existingPerson == null) return NotFound();

                var personEntity = Mapper.Map(person, existingPerson);
                var result = personService.Update(personEntity);

                if (result.IsValid)
                {
                    try
                    {
                        personService.SaveChanges();
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

            person.UFs = getUFList();
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            var person = getViewModelById(id);

            if (person != null)
            {
                return View(person);
            }

            return NotFound();
        }

        // POST: People/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var person = personService.GetById(id);

            if (person == null) return NotFound();

            var result = personService.Remove(person);

            if (result.IsValid)
            {
                personService.SaveChanges();
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
            return Mapper.Map<PersonViewModel>(personService.GetById(id));
        }

        IList<SelectListItem> getUFList()
        {
            var ufs = ufService.GetAll();
            return Mapper.Map<IList<SelectListItem>>(ufs);
        }

        #endregion
    }
}
