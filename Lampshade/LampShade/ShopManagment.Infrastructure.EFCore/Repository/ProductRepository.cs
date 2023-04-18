using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contract.Product;
using ShopManagment.Domain.ProductAgg;
using System.Collections.Generic;
using System.Linq;

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
            return _repository.Products.Select(x => new EditProduct()
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                Code = x.Code,
                Description = x.Description,
                IsInStock = x.IsInStock,
                Keywords = x.Keywords,
                MetaData = x.MetaData,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> Serach(ProductSearchModel searchModel)
        {
            var query = _repository.Products.Include(x=>x.Category)
                .Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name=x.Name,
                ShortDescription=x.ShortDescription,
                Code = x.Code,
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                Description=x.Description,
                IsInStock=x.IsInStock,
                Picture = x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                UnitPrice = x.UnitPrice
                
            });

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Name.Contains(searchModel.Code));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
