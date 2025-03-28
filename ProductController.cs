using MachineTest_NimapTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineTest_NimapTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {
            var products = _context.Products.Include(p => p.Category).AsQueryable();
            var paginatedProducts = await PaginatedList<Product>.CreateAsync(products, pageIndex, pageSize);
            return View(paginatedProducts);
        }
    }
}
