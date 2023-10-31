using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.Models;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestHomeController : ControllerBase
    {
        public readonly OLSContext db;
        public TestHomeController(OLSContext db)
        {
            this.db = db;
        }

        // test user vì user có chứa date, và để chắc chắn k có bug cho việc thực hiện quản lý
        [HttpGet("/GetAllUsers_HOME")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = db.Users.ToList();
            return Ok(users);
        }
    }
}
