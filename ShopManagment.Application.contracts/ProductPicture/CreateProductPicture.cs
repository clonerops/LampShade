namespace ShopManagment.Application.contracts.ProductPicture
{
    public class CreateProductPicture
    {
        public long ProductId { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string PictureUrl { get; set; }
    }
}
