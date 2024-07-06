using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.contracts.Product;
using ShopManagment.Application.contracts.ProductCategory;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Infrastructure.EFCore.Repository
{
    public class ProductRepository : ReposioryBase<long, Product>, IProductRepository
    {
        private readonly ShopManagmentContext _context;

        public ProductRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public ProductViewModel GetProduct(long id)
        {
            return _context.Products.Include(x => x.ProductCategory).Select(x => new ProductViewModel {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsInStock = x.IsInStock,
                ProductCategory = new ProductCategoryViewModel
                {
                    Id = x.ProductCategory.Id,
                    Name = x.ProductCategory.Name,
                    Description = x.ProductCategory.Description,
                    
                }
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _context.Products.Include(x => x.ProductCategory).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsInStock = x.IsInStock,
                ProductCategory = new ProductCategoryViewModel
                {
                    Id = x.ProductCategory.Id,
                    Name = x.ProductCategory.Name,
                    Description = x.ProductCategory.Description,

                }
            }).ToList();
        }
    }
}
