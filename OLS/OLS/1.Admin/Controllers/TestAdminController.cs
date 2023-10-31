using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.Models;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAdminController : ControllerBase
    {
        public readonly OLSContext db;
        public TestAdminController(OLSContext db)
        {
            this.db = db;
        }

        // test user vì user có chứa date, và để chắc chắn k có bug cho việc thực hiện quản lý
        [HttpGet("/GetAllUsers_ADMIN")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = db.Users.ToList();
            return Ok(users);
        }
    }
}
