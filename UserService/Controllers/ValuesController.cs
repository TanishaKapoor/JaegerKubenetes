using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("user")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        List<User> _userdb = new List<User>();
        UserContext context;
        public ValuesController()
        {
           
        }
        // GET api/values
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> Get()
        {
            context = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            _userdb = context.GetAllUsers();
            return Ok(_userdb);
        }

        // GET user/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            context = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            _userdb = context.GetAllUsers();
            var user = _userdb.Where(c => c.id == id).Select(c=>new {c.age,c.name,c.email}).FirstOrDefault();
            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
