using _0_Framework.Infrastructure;
using ShopManagment.Application.contracts.ProductPicture;
using ShopManagment.Domain.ProductPictureAgg;

namespace ShopManagment.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : ReposioryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopManagmentContext _context;

        public ProductPictureRepository(ShopManagmentContext context) : base(context)
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
