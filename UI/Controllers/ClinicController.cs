using BL.Api;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {

        IBLClinic data;

        public ClinicController(IBL blMan)
        {
            data = blMan.Clinics;
        }
        // GET: api/<ClinicController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(data.GetAll());
        }
        // GET api/<ClinicController>/5
        [HttpGet("getById/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(data.GetById(id));
        }

        // POST api/<ClinicController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClinicController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClinicController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
