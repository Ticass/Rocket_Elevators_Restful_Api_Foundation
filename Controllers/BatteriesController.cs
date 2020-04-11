using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TodoApi.Models;

namespace Rocket.Controllers {
    [Route ("api/batteries")]
    [ApiController]
    public class BatteriesController : ControllerBase {
        private readonly MysqlContext _context;

        public BatteriesController (MysqlContext context) {
            _context = context;
        }

        // GET api/batteries/5
        [HttpGet ("{id}")]
        public ActionResult GetById (string Status, long id) {
            var item = _context.batteries.Find (id);
            if (item == null) {
                return NotFound ("Not found");
            }
            var json = new JObject ();
            json["status"] = item.Status;
            return Content (json.ToString (), "application/json");
        }

        // PUT api/batteries/5
        [HttpPut ("{id}")]
        public ActionResult Update (long id, batteries battery) {
            var bat = _context.batteries.Find (id);
            if (bat == null) {
                return NotFound ();
            }

            bat.Status = battery.Status;

            _context.batteries.Update (bat);
            _context.SaveChanges ();
            return Content (bat.Status.ToString (), "application/json");
        }
    }}