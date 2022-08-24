using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftActivities.Models;

namespace SoftActivities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheduleController : ControllerBase
    {
        private SoftActivitiesContext _context;

        public SheduleController()
        {
            _context = new SoftActivitiesContext();
        }


        [HttpGet]
        public ActionResult<List<Schedule>> Get()
        {
            var listado = _context.Schedules;
            return Ok(listado);
        }

        [HttpPost]
        public ActionResult Post(Schedule Schedule)
        {
            _context.Schedules.Add(Schedule);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Schedule Schedule)
        {
            _context.Schedules.Update(Schedule);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var schedule = _context.Schedules.FirstOrDefault(x => x.IdSchedule == id);
            _context.Schedules.Remove(schedule);
            _context.SaveChanges();
            return Ok(schedule);
        }
    }
}
