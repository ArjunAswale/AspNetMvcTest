namespace MachineTest_NimapTask.Models
{
    public interface IProductService
    {
        Task<PaginatedList<Product>> GetProductsAsync(int pageIndex, int pageSize);
    }
}
