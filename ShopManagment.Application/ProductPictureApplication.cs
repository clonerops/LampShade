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
            var opeartion = new OperationResult();

            if (_productPictureRepository.Exist(x => x.ProductId == command.ProductId && x.PictureUrl == command.PictureUrl))
                return opeartion.Failed("رکورد تکراری می باشد");

            var productPicture = new ProductPicture(command.ProductId, command.PictureAlt, command.PictureTitle, command.PictureUrl);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return opeartion.Succedded();
            
        }

        public OperationResult Edit(EditProductPicture command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Remove(long Id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Restore(long Id)
        {
            throw new NotImplementedException();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
