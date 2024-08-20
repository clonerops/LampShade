using AccountManagment.Application.contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LampShade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountApplication _accountApplication;

        public AccountController(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        [HttpPost]
        public JsonResult CreateAccount(CreateAccount command)
        {
           var account = _accountApplication.Create(command);

            return new JsonResult(account);
        }

        [HttpGet]
        public List<AccountViewModel> GetAllAccount()
        {
            return _accountApplication.List();
        }

        [HttpGet("{id:long}")]
        public AccountViewModel GetBy(long id)
        {
            return _accountApplication.GetBy(id);
        }

        [HttpPut("{id:long}")]
        public JsonResult EditAccount([FromBody] EditAccount command)
        {
            var account = _accountApplication.Edit(command);

            return new JsonResult(account);
        }

        [HttpDelete("{id:long}")]
        public JsonResult DeleteAccount([FromRoute] long id)
        {
            var account = _accountApplication.Remove(id);

            return new JsonResult(account);
        }

        [HttpPut("Restore/{id:long}")]
        public JsonResult RestoreAccount([FromRoute] long id)
        {
            var account = _accountApplication.Restore(id);

            return new JsonResult(account);
        }

        [HttpPut("ChangePassword")]
        public JsonResult RestoreAccount([FromBody] ChangePassword command)
        {
            var account = _accountApplication.ChangePassword(command);

            return new JsonResult(account);
        }


    }
}
