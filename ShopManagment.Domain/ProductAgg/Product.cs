using _0_Framework.Domain;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Domain.ProductPictureAgg;

namespace ShopManagment.Domain.ProductAgg
{
    public class Product : EntityBase<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsInStock { get; set; }
        public long ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<ProductPicture> ProductPictures { get; set; }

        public Product(string name, string description, long productCategoryId)
        {
            Name = name;
            Description = description;
            ProductCategoryId = productCategoryId;
            IsInStock = false;
        }

        public void Edit(string name, string description, long productCategoryId)
        {
            Name = name;
            Description = description;
            ProductCategoryId = productCategoryId;
        }

        public void Remove()
        {
            IsDeleted = true;
        }
    }
}
