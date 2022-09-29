using Microsoft.AspNetCore.Mvc;
using EmployersWebApplication.Services;
using EmployersWebApplication.ViewModels;
using EmployersWebApplication.Models;

namespace EmployersWebApplication.Controllers
{
    public class EmployersController : Controller
    {
        private readonly IEmployersRepository _repository;
        public EmployersController(IEmployersRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var employers = _repository.GetAll();

            return View(employers);
        }
        public IActionResult Details(int id)
        {
            return View();
        }
        public IActionResult Create()
        {
            return View("Edit", new EmployerViewModels());
        }

        public IActionResult Edit(EmployerViewModels model)
        {
            var empl = new Employer
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Birthday = model.Birthday,
                Patronimic = model.Patronimic

            };

            if (empl.Id==0)
            {
                var id = _repository.Add(empl);
                return RedirectToAction("Details", new { id });
            }
            var success = _repository.Edit(empl);
            if (!success)
                return NotFound();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View();
        }
        public IActionResult Remove(int Id)
        {
            return View();
        }
    }
}
