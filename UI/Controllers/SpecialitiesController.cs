using BL;
using BL.Api;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialitiesController : ControllerBase
    {
        IBLSpeciality data;
        
        public SpecialitiesController(IBL blMan)
        {
            data = blMan.Specialities;
        }
        // GET: api/<SpecialitiesController>
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            return Ok(data.GetAll());
        }

        // GET api/<SpecialitiesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SpecialitiesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SpecialitiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpecialitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
