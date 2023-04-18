using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Application.Contract.Product;
using System.Collections.Generic;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        private readonly IProductApplication productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            this.productApplication = productApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            Products = productApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate(CreateProduct createProduct)
        {
            return Partial("./Create", new CreateProduct());
        }
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = productApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var product = productApplication.GetDetails(id);
            return Partial("./Edit", product);
        } 
        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = productApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
