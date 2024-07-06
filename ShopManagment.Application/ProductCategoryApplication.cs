using _0_Framework.Application;
using ShopManagment.Application.contracts.ProductCategory;
using ShopManagment.Application.contracts.ProductCategory.contract;
using ShopManagment.Domain.ProductCategoryAgg;

namespace ShopManagment.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            var productCategory = new ProductCategory(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keyword,
                command.MetaDescription, command.Slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(id);

            if (productCategory == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            productCategory.IsDeleted = true;
            _productCategoryRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);

            if (productCategory == null)
                return operation.Failed("رکورد با مشخصات درخواستی یافت نشد");

            //if(_productCategoryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
            //    return operation.Failed("امکان ثبت رکورد جدید وجود ندارد.");

            productCategory.Edit(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keyword,
                command.MetaDescription, command.Slug);

            _productCategoryRepository.SaveChanges();

            return operation.Succedded();
        }

        public ProductCategoryViewModel GetBy(long id)
        {
            return _productCategoryRepository.GetBy(id);
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> List()
        {
            return _productCategoryRepository.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(SearchProductCategory name)
        {
            return _productCategoryRepository.Search(name.Name);
        }
    }
}
