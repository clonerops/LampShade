using DiscountManagment.Application.contracts.CustomerDiscount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LampShade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDiscountController : ControllerBase
    {
        private readonly ICustomerDiscountApplication _customerDiscountApplication;

        public CustomerDiscountController(ICustomerDiscountApplication customerDiscountApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
        }

        [HttpPost]
        public JsonResult CreateCustomerDiscount([FromBody] CreateCustomerDiscount command)
        {
            var CustomerDiscount = _customerDiscountApplication.Create(command);
            return new JsonResult(CustomerDiscount);
        }

        [HttpGet]
        public JsonResult GetAllCustomerDiscount()
        {
            var CustomerDiscounts = _customerDiscountApplication.List();
            return new JsonResult(CustomerDiscounts);
        }

        //[HttpGet("{id:long}")]
        //public JsonResult GetCustomerDiscount([FromRoute] long id)
        //{
        //    var CustomerDiscount = _customerDiscountApplication.GetBy(id);
        //    return new JsonResult(CustomerDiscount);
        //}

        [HttpDelete("{id:long}")]
        public JsonResult DeleteCustomerDiscount([FromRoute] long id)
        {
            var CustomerDiscount = _customerDiscountApplication.Remove(id);
            return new JsonResult(CustomerDiscount);
        }

        [HttpPut("{id:long}")]
        public JsonResult EditCustomerDiscount([FromBody] EditCustomerDiscount command)
        {
            var CustomerDiscount = _customerDiscountApplication.Edit(command);
            return new JsonResult(CustomerDiscount);

        }


        [HttpPut("Restore/{id:long}")]
        public JsonResult RestoreCustomerDiscount([FromRoute] long id)
        {
            var CustomerDiscount = _customerDiscountApplication.Restore(id);
            return new JsonResult(CustomerDiscount);

        }



    }
}
