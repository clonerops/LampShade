using _0_Framework.Domain;
using ShopManagment.Application.Contract.Product;
using System.Collections.Generic;

namespace ShopManagment.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long, Product>
    {
        EditProduct GetDetails (long id);
        List<ProductViewModel> Serach(ProductSearchModel searchModel);
    }
}
