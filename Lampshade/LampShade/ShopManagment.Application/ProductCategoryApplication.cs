using _0_Framework.Application;
using ShopManagment.Application.Contract.ProductCategory;
using ShopManagment.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;

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
            var opertaion = new OperationResult();

            if(_productCategoryRepository.Exists(x => x.Name == command.Name))
                return opertaion.Failure("امکان ثبت رکورد تکراری وجود ندارد.");
            var slug = command.Slug.Slugify();

            var productCategory = new ProductCategory(
                command.Name, command.Description, command.PictureAlt, command.Picture, command.PictureTitle,
                command.Keywords, command.MetaData, slug);
            _productCategoryRepository.Add(productCategory);

            _productCategoryRepository.SaveChanges();
            return opertaion.Success();

        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.GetById(command.Id);
            
            if(productCategory == null)
                return operation.Failure("رکورد موردنظر یافت نشد!");

            if(_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failure("امکان ثبت رکورد تکراری وجود ندارد.");

            var slug = command.Slug.Slugify();

            productCategory.Edit(
                 command.Name, command.Description, command.PictureAlt, command.Picture, command.PictureTitle,
                command.Keywords, command.MetaData, slug);
            _productCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public EditProductCategory GetDatils(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
