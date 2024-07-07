using _0_Framework.Domain;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public List<Product> Products { get; set; }

        public ProductCategory() 
        { 
            Products = new List<Product>();
        }

        public ProductCategory(string name, string description, string picture, 
            string pictureAlt, string pictureTitle, string keyword, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keyword = keyword;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void Edit(string name, string description, string picture,
            string pictureAlt, string pictureTitle, string keyword, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keyword = keyword;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void Removed()
        {
            IsDeleted = true;
        }
    }
}
