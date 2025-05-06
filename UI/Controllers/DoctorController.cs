using BL.Api;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        public IBLDoctor data { get; }
        public DoctorController(IBL blMan)
        {
            data = blMan.Doctors;
        }
        // GET: api/<DoctorsController>
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            return Ok(data.GetAll());
        }

        // GET api/<DoctorsController>/5
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(data.GetById(id));
        }

        // POST api/<DoctorsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DoctorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoctorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
