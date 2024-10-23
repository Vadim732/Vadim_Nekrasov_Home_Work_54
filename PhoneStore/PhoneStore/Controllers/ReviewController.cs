using Microsoft.AspNetCore.Mvc;
using PhoneStore.Models;

namespace PhoneStore.Controllers;

public class ReviewController : Controller
{
    private readonly PhoneStoreContext _context;

    public ReviewController(PhoneStoreContext context)
    {
        _context = context;
    }
    
    public IActionResult Create(int phoneId)
    {
        Phone phone = _context.Phones.FirstOrDefault(p => p.Id == phoneId);
        return View(new Review() { Phone = phone });
    }

    [HttpPost]
    public IActionResult Create(Review review)
    {
        if (ModelState.IsValid)
        {
            _context.Add(review);
            _context.SaveChanges();

            return RedirectToAction("Index", "Phone");
        }

        return NotFound();
    }
}