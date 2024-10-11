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
    
    public IActionResult Details(int phoneId)
    {
        Phone phone = _context.Phones.FirstOrDefault(p => p.Id == phoneId);
        if (phone != null)
        {
            return View(phone);
        }

        return NotFound();
    }

    public IActionResult Edit(int phoneId)
    {
        Phone phone = _context.Phones.FirstOrDefault(p => p.Id == phoneId);
        if (phone != null)
        {
            return View(phone);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Edit(Phone phone)
    {
        _context.Update(phone);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Brand(string phoneCompany)
    {
        Phone phone = _context.Phones.FirstOrDefault(p => p.Company == phoneCompany);
        string urlCompany = $"https://www.{phone.Company}.com";
        return Redirect(urlCompany);
    }
}