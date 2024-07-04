using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.contracts.ProductCategory;
using ShopManagment.Application.contracts.ProductCategory.contract;

namespace LampShade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryApplication _productCategoryApplication;

        public ProductCategoryController(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        /// <summary>
        /// لیست تمامی دسته بندی های محصول
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductCategoryViewModel> GetAllProductCategory()
        {
            return _productCategoryApplication.List();
        }

        /// <summary>
        /// ایجاد دسته بندی محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void CreateProductCategory([FromBody] CreateProductCategory command)
        {
            _productCategoryApplication.Create(command);
        }

        /// <summary>
        /// ویرایش دسته محصول
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id}")]
        public void EditProductCategory([FromBody] EditProductCategory command)
        {
             _productCategoryApplication.Edit(command);
        }
    }
}
