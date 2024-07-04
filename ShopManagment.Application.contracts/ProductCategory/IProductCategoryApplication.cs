using _0_Framework.Application;

namespace ShopManagment.Application.contracts.ProductCategory.contract
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        List<ProductCategoryViewModel> Search(SearchProductCategory name);
        List<ProductCategoryViewModel> List();
        EditProductCategory GetDetails(long id);

    }
}
