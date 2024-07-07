using _0_Framework.Domain;
using ShopManagment.Application.contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long, Product>
    {
        List<ProductViewModel> GetProducts();
        ProductViewModel GetProduct(long id);

    }
}
