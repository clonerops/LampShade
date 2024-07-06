using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.contracts.Product;

namespace LampShade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        /// <summary>
        /// ایجاد محصول جدید
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateProduct([FromBody] CreateProduct command)
        {
            var result = _productApplication.Create(command);

            return new JsonResult(result);
        }

        /// <summary>
        /// دریافت لیست تمامی محصولات
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductViewModel> GetProducts()
        {
            return _productApplication.GetProducts();
        }

        /// <summary>
        /// دریافت جرئیات محصول با کد یونیک
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public ProductViewModel GetProduct([FromRoute] int id)
        {
            return _productApplication.GetProduct(id);
        }

        [HttpPut("{id:long}")]
        public JsonResult EditProduct([FromBody] EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
