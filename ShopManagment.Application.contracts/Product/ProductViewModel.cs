using ShopManagment.Application.contracts.ProductCategory;

namespace ShopManagment.Application.contracts.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsInStock { get; set; }
        public ProductCategoryViewModel ProductCategory { get; set; }
    }

}
