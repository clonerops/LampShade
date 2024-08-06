using DiscountManagment.Application.contracts.ColleagueDiscount;
using Microsoft.AspNetCore.Mvc;

namespace LampShade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColleaugeDiscountController : ControllerBase
    {
        private readonly IColleagueDiscountApplication _colleaugeDiscountApplication;

        public ColleaugeDiscountController(IColleagueDiscountApplication ColleaugeDiscountApplication)
        {
            _colleaugeDiscountApplication = ColleaugeDiscountApplication;
        }

        [HttpPost]
        public JsonResult CreateColleaugeDiscount([FromBody] CreateColleagueDiscount command)
        {
            var ColleaugeDiscount = _colleaugeDiscountApplication.Create(command);
            return new JsonResult(ColleaugeDiscount);
        }

        [HttpGet]
        public JsonResult GetAllColleaugeDiscount()
        {
            var ColleaugeDiscounts = _colleaugeDiscountApplication.List();
            return new JsonResult(ColleaugeDiscounts);
        }

        //[HttpGet("{id:long}")]
        //public JsonResult GetColleaugeDiscount([FromRoute] long id)
        //{
        //    var ColleaugeDiscount = _ColleaugeDiscountApplication.GetBy(id);
        //    return new JsonResult(ColleaugeDiscount);
        //}

        [HttpDelete("{id:long}")]
        public JsonResult DeleteColleaugeDiscount([FromRoute] long id)
        {
            var ColleaugeDiscount = _colleaugeDiscountApplication.Remove(id);
            return new JsonResult(ColleaugeDiscount);
        }

        [HttpPut("{id:long}")]
        public JsonResult EditColleaugeDiscount([FromBody] EditColleagueDiscount command)
        {
            var ColleaugeDiscount = _colleaugeDiscountApplication.Edit(command);
            return new JsonResult(ColleaugeDiscount);

        }


        [HttpPut("Restore/{id:long}")]
        public JsonResult RestoreColleaugeDiscount([FromRoute] long id)
        {
            var ColleaugeDiscount = _colleaugeDiscountApplication.Restore(id);
            return new JsonResult(ColleaugeDiscount);

        }



    }
}
