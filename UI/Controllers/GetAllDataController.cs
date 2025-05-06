using BL.Api;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllDataController : ControllerBase
    {
        IBL data;
        public GetAllDataController(IBL blman)
        {
            data = blman;   
        }
        // GET: api/<GetAllDataController>
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            return Ok(new { queues = data.Queues.GetAll() ,
                            avialableQueues = data.AvialableQueues.GetAllStartQueues() ,
                            patients = data.Patients.GetAll() ,
                            clinics = data.Clinics.GetAll() ,
                            doctors = data.Doctors.GetAll() });
        }

        // GET api/<GetAllDataController>/5
        [HttpGet("getQueuesData")]
        public IActionResult GetQueus()
        {
            return Ok(new {
                queues = data.Queues.GetAll(),
                avialableQueues = data.AvialableQueues.GetAllStartQueues()
            });
        }

        // POST api/<GetAllDataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GetAllDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetAllDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
