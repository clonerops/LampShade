using _0_Framework.Domain;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Domain.ProductPictureAgg
{
    public class ProductPicture : EntityBase<long>
    {
        public long ProductId { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string PictureUrl { get; set; }
        public Product Product { get; set; }

        public ProductPicture(long productId, string pictureAlt, string pictureTitle, string pictureUrl)
        {
            ProductId = productId;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PictureUrl = pictureUrl;
            IsDeleted = false;
        }

        public void Edit(long productId, string pictureAlt, string pictureTitle, string pictureUrl)
        {
            ProductId = productId;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PictureUrl = pictureUrl;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
