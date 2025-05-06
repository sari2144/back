using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IBLPatient data;

        public PatientController(IBL blMan)
        {
            data = blMan.Patients;
        }


        // GET: api/<PatientController>
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            return Ok(data.GetAll());
        }

        // GET api/<PatientController>/5
        [HttpGet("getById/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(data.GetById(id));
        }

        // POST api/<PatientController>
        [HttpPost("add")]
        public IActionResult Post([FromBody] BLPatient newP)
        {
             return Ok(data.Add(newP));
        }
        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
