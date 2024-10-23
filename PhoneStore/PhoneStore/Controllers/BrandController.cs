using Microsoft.AspNetCore.Mvc;
using PhoneStore.Models;

namespace PhoneStore.Controllers;

public class BrandController : Controller
{
    private readonly PhoneStoreContext _context;

    public BrandController(PhoneStoreContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        List<Brand> brands = _context.Brands.ToList();
        return View(brands);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Brand brand)
    {
        if (brand != null)
        {
            _context.Add(brand);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        return View(brand);
    }

    public IActionResult Delete(int brandId)
    {
        Brand brand = _context.Brands.FirstOrDefault(b => b.Id == brandId);
        if (brand != null)
        {
            _context.Remove(brand);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}