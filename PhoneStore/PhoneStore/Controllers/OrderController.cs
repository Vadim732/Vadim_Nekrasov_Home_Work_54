using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Models;

namespace PhoneStore.Controllers;

public class OrderController : Controller
{
    private readonly PhoneStoreContext _context;

    public OrderController(PhoneStoreContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Order> orders = _context.Orders.Include(o => o.Phone).ToList();
        return View(orders);
    }

    public IActionResult Create(int phoneId)
    {
        Phone phone = _context.Phones.FirstOrDefault(p => p.Id == phoneId);
        return View(new Order() { Phone = phone });
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        if (order != null)
        {
            _context.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index", "Phone");
        }

        return NotFound();
    }

    public IActionResult Delete(int orderId)
    {
        Order order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            _context.Remove(order);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}