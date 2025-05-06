using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        IBLQueue data;
        public QueueController(IBL blMan)
        {
            data = blMan.Queues;
        }
        // GET: api/<QueueController>
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            return Ok(data.GetAll());
        }

        // GET api/<QueueController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QueueController>
        [HttpPost("add")]
        public IActionResult Post([FromBody] BLQueue newQ)
        {
           return Ok(data.DetermineNewQueue(newQ));
        }

        // PUT api/<QueueController>/5
        [HttpPut("update")]
        public void Put( [FromBody] BLQueue q)
        {
            data.Update(q);
        }

        // DELETE api/<QueueController>/5
        [HttpDelete("cancelQueue/{backToAvialable}")]
        public void Delete([FromBody] BLQueue queue , bool backToAvialable)
        {
            data.CancelQueue(queue, backToAvialable);
        }
    }
}
