using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ShopManagment.Application.contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }

    }
}
