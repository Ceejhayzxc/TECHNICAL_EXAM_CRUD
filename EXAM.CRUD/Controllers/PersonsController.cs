using EXAM.CRUD.Common;
using EXAM.CRUD.Interfaces;
using EXAM.CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EXAM.CRUD.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonsRepository _personRepo;

        public PersonsController(IPersonsRepository personRepo)
        {
            _personRepo = personRepo;
        }
        public async Task<IActionResult> Index(string? search)
        {
            var persons = await _personRepo.GetSearch(search ?? string.Empty);
            return View(persons.Results ?? Enumerable.Empty<Persons>());
        }

        //public IActionResult Create()
        //{
        //    return View(new Persons());
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePerson(Persons person)
        {
            if (!ModelState.IsValid)
            {
                var persons = await _personRepo.GetAllAsync();
                ViewData["ShowCreateModal"] = true;
                return View("Index", persons);
            }

            if (person.birthDate == DateOnly.FromDateTime(DateTime.UtcNow))
            {
                TempData["Message"] = "Birth date should not be equal to today's date.";
                return RedirectToAction("Index");
            }

            await _personRepo.CreateAsync(person);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var updatePerson = await _personRepo.GetOneAsync(id);
            if (updatePerson == null)
            {
                return NotFound();
            }

            return View(updatePerson);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Persons person)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", person);
            }

            await _personRepo.UpdateAsync(person);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id, Persons person)
        {
            var deletePerson = await _personRepo.GetOneAsync(id);
            if (deletePerson == null)
            {
                return NotFound();
            }

            await _personRepo.DeleteAsync(deletePerson);
            return RedirectToAction(nameof(Index));
        }
    }
}
