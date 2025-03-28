using Microsoft.EntityFrameworkCore;

namespace MachineTest_NimapTask.Models
{
    public class ProductService: IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Product>> GetProductsAsync(int pageIndex, int pageSize)
        {
            var query = _context.Products.Include(p => p.Category).AsQueryable();
            return await PaginatedList<Product>.CreateAsync(query, pageIndex, pageSize);
        }
    }
}
