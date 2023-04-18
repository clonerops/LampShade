using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Application.Contract.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct product);
        OperationResult Edit(EditProduct product);
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
