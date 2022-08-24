using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftActivities.Models;

namespace SoftActivities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateController : ControllerBase
    {


        private SoftActivitiesContext _context;

        public DateController()
        {
            _context = new SoftActivitiesContext();
        }


        [HttpGet]
        public ActionResult<List<Date>> Get()
        {
            var listado = _context.Dates;
            return Ok(listado);
        }

        [HttpPost]
        public ActionResult Post(Date date)
        {
            _context.Dates.Add(date);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Date date)
        {
            _context.Dates.Update(date);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var date = _context.Dates.FirstOrDefault(x => x.IdDate == id);
            _context.Dates.Remove(date);
            _context.SaveChanges();
            return Ok(date);
        }
    }
}

