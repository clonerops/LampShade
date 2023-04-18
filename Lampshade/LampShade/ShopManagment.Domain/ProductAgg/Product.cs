using _0_Framework.Domain;
using ShopManagment.Domain.ProductCategoryAgg;

namespace ShopManagment.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string MetaData { get; private set; }
        public string Keywords { get; private set; }
        public string Slug { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }

        public Product(string name, long categoryId, double unitPrice, 
            string shortDescription, string description, 
            string pictureAlt, bool isInStock, string picture, 
            string code, string pictureTitle, string metaData, 
            string keywords, string slug)
        {
            Name = name;
            CategoryId = categoryId;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            PictureAlt = pictureAlt;
            IsInStock = isInStock;
            Picture = picture;
            Code = code;
            PictureTitle = pictureTitle;
            MetaData = metaData;
            Keywords = keywords;
            Slug = slug;
        }

        public void Edit(string name, long categoryId, string code, string description,
            double unitPrice, string shortDescription,
            string picture, string pictureAlt, string pictureTitle,
            string metadData, string keywords,
            string slug)
        {
            Name = name;
            Code = code;
            Description = description;
            UnitPrice = unitPrice;
            IsInStock = false;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaData = metadData;
            Keywords = keywords;
            CategoryId = categoryId;
            Slug = slug;
        }
        public void InStock()
        {
            IsInStock = true;
        }
        public void NotInStock()
        {
            IsInStock=false;
        }
    }
}
