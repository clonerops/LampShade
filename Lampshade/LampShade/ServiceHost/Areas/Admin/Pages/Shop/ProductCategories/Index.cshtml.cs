using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Application.Contract.ProductCategory;
using System.Collections.Generic;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel;
        public List<ProductCategoryViewModel> ProductCategories;
        private readonly IProductCategoryApplication productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = productCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate(CreateProductCategory createProduct)
        {
            return Partial("./Create", new CreateProductCategory());
        }
        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = productCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var product = productCategoryApplication.GetDatils(id);
            return Partial("./Edit", product);
        } public JsonResult OnPostEdit(EditProductCategory command)
        {
            var result = productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
