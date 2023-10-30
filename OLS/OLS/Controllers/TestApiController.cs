using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.Models;

namespace OLS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        public readonly F8DBContext db;
        public TestApiController(F8DBContext db)
        {
            this.db = db;
        }

        // test user vì user có chứa date, và để chắc chắn k có bug cho việc thực hiện quản lý
        [HttpGet("/GetAllUsers_TESTAPI")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = db.Users.ToList();
            return Ok(users);
        }

        // test blog comment có chứa datetime
        [HttpGet("/GetAllBlogComments_TESTAPI")]
        public ActionResult<IEnumerable<BlogComment>> GetAllBlogComments()
        {
            var blogComments = db.BlogComments.ToList();
            return Ok(blogComments);
        }
    }
}
