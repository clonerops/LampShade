using _0_Framework.Application;

namespace ShopManagment.Application.contracts.Product
{
    public interface IProductApplication 
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        List<ProductViewModel> GetProducts();
        ProductViewModel GetProduct(long id);
        OperationResult Remove(long id);
    }

}
