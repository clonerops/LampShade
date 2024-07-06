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
        /// ایجاد دسته بندی محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateProductCategory([FromBody] CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
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
        /// دریافت جزئیات دسته بندی محصول براساس کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public ProductCategoryViewModel GetProductCategoryById(long id)
        {
            return _productCategoryApplication.GetBy(id);
        }

        /// <summary>
        /// ویرایش دسته محصول
        /// </summary>
        /// <param name="command"></param>
        [HttpPut("{id:long}")]
        public JsonResult EditProductCategory([FromBody] EditProductCategory command)
        {
           var result =  _productCategoryApplication.Edit(command);
           return new JsonResult(result);
        }
        /// <summary>
        /// حذف منطقی دسته بندی محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public JsonResult DeleteProductCategory([FromRoute] long id)
        {
            var result = _productCategoryApplication.Delete(id);
            return new JsonResult(result);
        }
    }
}
