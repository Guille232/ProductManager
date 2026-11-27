using Microsoft.AspNetCore.Mvc;
using ProductManager.Data;
using ProductManager.Models;

namespace ProductManager.Controllers;

public class ProductsController : Controller
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        TempData["Success"] = "Producto registrado correctamente.";

        return RedirectToAction(nameof(Create));
    }
}
