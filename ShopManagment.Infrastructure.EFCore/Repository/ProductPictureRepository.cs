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

        public ProductPictureViewModel GetBy(long id)
        {
            var query = _context.ProductPictures.Select(x => new ProductPictureViewModel
            {
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PictureUrl = x.PictureUrl,
                ProductId = x.ProductId
            });
            return query.FirstOrDefault(x => x.Id == id);
        }

        public EditProductPicture GetDetails(long id)
        {
            return _context.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PictureUrl = x.PictureUrl,
                ProductId = x.ProductId 
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductPictureViewModel> List()
        {
            var query = _context.ProductPictures.Select(x => new ProductPictureViewModel
            {
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PictureUrl = x.PictureUrl,
                ProductId = x.ProductId
            });
            return query.OrderByDescending(x => x.Id).ToList();

        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _context.ProductPictures.Select(x => new ProductPictureViewModel
            {
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PictureUrl = x.PictureUrl,
                ProductId = x.ProductId
            });

            if (searchModel.ProductId != 0)
                query.Where(x => x.ProductId == searchModel.ProductId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
