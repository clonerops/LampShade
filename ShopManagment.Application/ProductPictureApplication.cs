using _0_Framework.Application;
using ShopManagment.Application.contracts.ProductPicture;
using ShopManagment.Domain.ProductPictureAgg;

namespace ShopManagment.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();

            if (_productPictureRepository.Exist(x => x.ProductId == command.ProductId && x.PictureUrl == command.PictureUrl))
                return operation.Failed("رکورد تکراری می باشد");

            var productPicture = new ProductPicture(command.ProductId, command.PictureAlt, command.PictureTitle, command.PictureUrl);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
            
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();

            var productPicture = _productPictureRepository.Get(command.Id);

            if (productPicture == null)
                return operation.Failed("رکورد پیدا نشد");

            productPicture.Edit(command.ProductId, command.PictureAlt, command.PictureTitle, command.PictureUrl);
            _productPictureRepository.SaveChanges();
            return operation.Succedded();

        }

        public ProductPictureViewModel GetBy(long Id)
        {
            return _productPictureRepository.GetBy(Id);
        }

        public List<ProductPictureViewModel> List()
        {
            return _productPictureRepository.List();
        }

        public OperationResult Remove(long Id)
        {
            var operation = new OperationResult();

            var productPicture = _productPictureRepository.Get(Id);

            if (productPicture == null)
                return operation.Failed("رکورد پیدا نشد");
            productPicture.Remove();
            _productPictureRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Restore(long Id)
        {
            var operation = new OperationResult();
            
            var productPicture = _productPictureRepository.Get(Id);

            if (productPicture == null)
                return operation.Failed("رکورد پیدا نشد");
            productPicture.Restore();
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}
