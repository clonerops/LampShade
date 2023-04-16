using _0_Framework.Infrastructure;
using ShopManagment.Application.Contract.ProductCategory;
using ShopManagment.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly EfContext _repository;

        public ProductCategoryRepository(EfContext repository) : base(repository)
        {
            _repository = repository;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _repository.ProductCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                Keywords = x.Keywords,
                MetaData = x.MetaData,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _repository.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToString()
            });
            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name == searchModel.Name);
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
