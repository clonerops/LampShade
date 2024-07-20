using _0_Framework.Domain;
using ShopManagment.Application.contracts.ProductPicture;

namespace ShopManagment.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long, ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> List();
        ProductPictureViewModel GetBy(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
