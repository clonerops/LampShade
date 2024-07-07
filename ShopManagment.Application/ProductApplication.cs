using _0_Framework.Application;
using ShopManagment.Application.contracts.Product;
using ShopManagment.Domain.ProductAgg;
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
                        
            if (_productRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت محصول تکراری وجود ندارد");

            var product = new Product(command.Name, command.Description, command.ProductCategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChanges();

            return operation.Succedded();
            
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();

            var product = _productRepository.Get(command.Id);

            if (product == null)
                return operation.Failed("محصولی با چنین مشخصات یافت نشد");

            product.Edit(command.Name, command.Description, command.ProductCategoryId);
            _productRepository.SaveChanges();

            return operation.Succedded();
        }

        public ProductViewModel GetProduct(long id)
        {
            return _productRepository.GetProduct(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);

            if (product == null)
                return operation.Failed("محصولی با این مشخصات یافت نشد");

            product.Remove();
            _productRepository.SaveChanges();

            return operation.Succedded();

        }
    }
}
