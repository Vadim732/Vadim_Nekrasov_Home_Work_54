using Microsoft.AspNetCore.Mvc;
using PhoneStore.Models;

namespace PhoneStore.Controllers;

public class PhoneController : Controller
{
    private readonly PhoneStoreContext _context;

    public PhoneController(PhoneStoreContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        List<Phone> phones = _context.Phones.ToList();
        return View(phones);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Phone? phone)
    {
        if (phone != null)
        {
            _context.Add(phone);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(phone);
    }

    [HttpPost]
    public IActionResult Delete(int phoneId)
    {
        Phone phone = _context.Phones.FirstOrDefault(p => p.Id == phoneId);
        if (phone != null)
        {
            _context.Remove(phone);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}