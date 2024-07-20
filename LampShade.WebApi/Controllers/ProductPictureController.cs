using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagment.Application.contracts.ProductPicture;

namespace LampShade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPictureController : ControllerBase
    {
        private readonly IProductPictureApplication _productPictureApplication;

        public ProductPictureController(IProductPictureApplication productPictureApplication)
        {
            _productPictureApplication = productPictureApplication;
        }

        [HttpPost]
        public JsonResult CreateProductPicture([FromBody] CreateProductPicture command)
        {
            var productPicture = _productPictureApplication.Create(command);
            return new JsonResult(productPicture);
        }

        [HttpGet]
        public JsonResult GetAllProductPicture()
        {
            var productPictures = _productPictureApplication.List();
            return new JsonResult(productPictures);
        }

        [HttpGet("{id:long}")]
        public JsonResult GetProductPicture([FromRoute] long id)
        {
            var productPicture = _productPictureApplication.GetBy(id);
            return new JsonResult(productPicture);
        }

        [HttpDelete("{id:long}")]
        public JsonResult DeleteProductPicture([FromRoute] long id)
        {
            var productPicture = _productPictureApplication.Remove(id);
            return new JsonResult(productPicture);
        }

        [HttpPut("{id:long}")]
        public JsonResult EditProductPicture([FromBody] EditProductPicture command)
        {
            var productPicture = _productPictureApplication.Edit(command);
            return new JsonResult(productPicture);

        }


        [HttpPut("Restore/{id:long}")]
        public JsonResult RestoreProductPicture([FromRoute] long id)
        {
            var productPicture = _productPictureApplication.Restore(id);
            return new JsonResult(productPicture);

        }



    }
}
