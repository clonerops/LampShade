namespace ShopManagment.Application.Contract.Product
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public bool IsInStock { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

    }
}
