using _0_Framework.Application;
using ShopManagment.Application.Contract.Product;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Infrastructure.EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if(_productRepository.Exists(x => x.Name == command.Name))
            {
               return operation.Failure(OperationMessage.DuplicateMessage);
            }
            var slug = command.Slug.Slugify();

            var product = new Product(command.Name, command.CategoryId, 
                command.UnitPrice, command.ShortDescription, 
                command.Description, command.PictureAlt, command.IsInStock,
                command.Picture, command.Code, command.PictureTitle, 
                command.MetaData, command.Keywords, slug);

            _productRepository.Add(product);
            _productRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);
            if(product == null)
              return operation.Failure(OperationMessage.NotFoundMessage);
            if(_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
              return operation.Failure(OperationMessage.DuplicateMessage);
            var slug = command.Slug.Slugify();
            
            product.Edit(
                command.Name, command.CategoryId, command.Code, command.Description,
                command.UnitPrice, command.ShortDescription, command.Picture,
                command.PictureAlt, command.PictureTitle, command.MetaData, command.Keywords, slug);
            _productRepository.SaveChanges();
            return operation.Success();
        }

        public EditProduct GetDetails(long id)
        {
           return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Serach(searchModel);
        }
    }
}
