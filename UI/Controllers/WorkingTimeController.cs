using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingTimeController : ControllerBase
    {
        IBLWorkingTime data;
        public WorkingTimeController(IBL blMan)
        {
            data = blMan.WorkingTimes;
        }
        // GET: api/<WorkingTimeController>
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            return Ok(data.GetAll());
        }

        // GET api/<WorkingTimeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WorkingTimeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WorkingTimeController>/5
        [HttpPut("update")]
        public void Put([FromBody] BLWorkingTime wt)
        {
            data.Update(wt);
        }

        // DELETE api/<WorkingTimeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
