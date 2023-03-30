using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.ProductCategoryAgg
{
    internal interface IProductCategoryRepository
    {
        void Add(ProductCategory category);
        ProductCategory GetById(long id);
        ProductCategory GetByName(string name);
        List<ProductCategory> GetAll();
    }
}
