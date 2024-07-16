using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>();
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        [HttpPost]
        [ProducesResponseType(typeof(User), 201)]
        [ProducesResponseType(typeof(Error), 400)]
        public IActionResult Post([FromBody] UserRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                Error error = new Error();
                error.Message = "The Name field is required";
                return BadRequest(error);
            }
            User user = new User();
            user.Email = request.Email;
            user.Name = request.Name;
            user.Job = request.Job;
            user.Id = users.Count() + 1;

            users.Add(user);

           return CreatedAtAction("Get", new {id = user.Id}, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User request)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                user.Id = id;
                user.Name = request.Name;
                user.Email = request.Email;
                user.Job = request.Job;
                return Ok(user);
            }
        }

            // DELETE api/<UserController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                var user = users.FirstOrDefault(x => x.Id == id);
                users.Remove(user);
            }
        }
    } 
