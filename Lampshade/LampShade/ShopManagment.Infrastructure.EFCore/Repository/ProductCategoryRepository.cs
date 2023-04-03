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
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EfContext _repository;

        public ProductCategoryRepository(EfContext repository)
        {
            _repository = repository;
        }

        public void Add(ProductCategory category)
        {
            _repository.ProductCategories.Add(category);
        }

        public bool Exists(Expression<Func<ProductCategory, bool>> expression)
        {
           return _repository.ProductCategories.Any(expression);
        }

        public List<ProductCategory> GetAll()
        {
           return _repository.ProductCategories.ToList();
        }

        public ProductCategory GetById(long id)
        {
            return _repository.ProductCategories.Find(id);
        }

        public ProductCategory GetByName(string name)
        {
            return _repository.ProductCategories.Find(name);
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

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _repository.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString()
            });
            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name == searchModel.Name);
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
