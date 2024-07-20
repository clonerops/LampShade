namespace ShopManagment.Application.contracts.ProductPicture
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string PictureUrl { get; set; }
    }
}
