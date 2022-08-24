using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftActivities.Models;

namespace SoftActivities.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    
    public class UserController : ControllerBase
    {

        private SoftActivitiesContext _context;

        public UserController()
        {
            _context = new SoftActivitiesContext();
        }


        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var listado = _context.Users;
            return Ok(listado);
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = _context.Users.FirstOrDefault(x => x.IdUser== id);
            _context.Users.Remove(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }
    }
}

