using _0_Framework.Domain;
using ShopManagment.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keywords { get; private set; }
        public string MetaData { get; private set; }
        public string Slug { get; private set; }
        public List<Product> Products { get; set; }

        public ProductCategory()
        {
            Products = new List<Product>();
        }

        public ProductCategory(string name, string description, string picture, string pictureAlt, string pictureTitle,
            string keywords, string metaData, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaData = metaData;
            Slug = slug;
        }

        public void Edit(string name, string description, string picture, string pictureAlt, string pictureTitle,
            string keywords, string metaData, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaData = metaData;
            Slug = slug;
        }
    }
}
