namespace ShopManagment.Application.contracts.Product
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long ProductCategoryId { get; set; }
    }

}
