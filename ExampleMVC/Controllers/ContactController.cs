using ExampleMVC.Context;
using ExampleMVC.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExampleMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactContext _context;

        public ContactController(
            ContactContext context
        ) =>
            _context = context;

        public IActionResult Index()
        {
            var contacts = _context.Contacts.ToList();

            return View(contacts);
        }
    
        //HttpGet (implicit)
        public IActionResult Create() =>
            View();

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var dbContact = _context.Contacts.Find(contact.Id);

            dbContact.Name = contact.Name;
            dbContact.PhoneNumber = contact.PhoneNumber;
            dbContact.IsActive = contact.IsActive;

            _context.Update(dbContact);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
                return RedirectToAction(nameof(Index));

            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
                return RedirectToAction(nameof(Index));

            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            var dbContact = _context.Contacts.Find(contact.Id);

            _context.Contacts.Remove(dbContact);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}