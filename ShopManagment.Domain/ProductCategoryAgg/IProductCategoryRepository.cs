using _0_Framework.Domain;
using ShopManagment.Application.contracts.ProductCategory;
using System.Linq.Expressions;

namespace ShopManagment.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long, ProductCategory>
    {
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> GetProductCategories();
        List<ProductCategoryViewModel> Search(string name);
    }
}
