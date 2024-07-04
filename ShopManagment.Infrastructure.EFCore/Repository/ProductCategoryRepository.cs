using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using ShopManagment.Application.contracts.ProductCategory;
using ShopManagment.Domain.ProductCategoryAgg;
using System.Linq.Expressions;

namespace ShopManagment.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : ReposioryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopManagmentContext _context;

        public ProductCategoryRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            return _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).Where(x => x.Name == name).ToList();
        }
    }
}
