using _0_Framework.Infrastructure;
using ShopManagment.Application.Contract.Product;
using ShopManagment.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly EfContext _repository;

        public ProductRepository(EfContext repository) : base(repository)
        {
            _repository = repository;
        }

        public EditProduct GetDetails(long id)
        {
            var query = _repository
        }

        public List<ProductViewModel> Serach(ProductSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
