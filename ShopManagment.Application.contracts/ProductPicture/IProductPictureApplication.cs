using _0_Framework.Application;

namespace ShopManagment.Application.contracts.ProductPicture
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        OperationResult Remove(long Id);
        OperationResult Restore(long Id);
        List<ProductPictureViewModel> List();
        ProductPictureViewModel GetBy(long Id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
