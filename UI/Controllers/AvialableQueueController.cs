using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvialableQueueController : ControllerBase
    {
        IBLAvialableQueue data;
        public AvialableQueueController(IBL blMan)
        {
            data = blMan.AvialableQueues;
        }
        // GET: api/<AvialableQueueController>
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            return Ok(data.GetAll());
        }

        [HttpGet("getAllStartQueue")]
        public IActionResult GetAllStartQueue()
        {
            return Ok(data.GetAllStartQueues());
        }
        /// <summary>
        //
        /// </summary>
        /// <returns></returns>
        [HttpGet("getDate")]
        public IActionResult GetMyDate()
        {
            return Ok(new {d=  new DateTime(2020 , 5 , 10).ToString("MM/dd/yyyy") });
        }
        /// <summary>
        
        /// <returns></returns>
        [HttpGet("getByCondition/{id}/{dayWeek?}/{doctorName?}/{city?}/{minHour?}/{maxHour?}/{date?}/{isDouble?}")]

        public IActionResult GetByCondition(string id, string? dayWeek, string ?doctorName=null, string? city=null, int minHour=-1, int maxHour =-1 , DateTime date = new DateTime() , bool isDouble=false)
        {
            Console.WriteLine(id + " " + dayWeek + " " + date + isDouble);
            return Ok(data.SearchAvialableQueueByConditiones(id , dayWeek , doctorName , city , minHour , maxHour , date , isDouble));
        }
        // GET api/<AvialableQueueController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AvialableQueueController>
        [HttpPost("add")]
        public void Post([FromBody] BLAvialableQueue newQ)
        {
            data.Add(newQ);
        }

        // PUT api/<AvialableQueueController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AvialableQueueController>/5
        [HttpDelete("delete")]
        public void Delete([FromBody] BLAvialableQueue aq)
        {
            data.Remove(aq);
        }

        [HttpDelete("deleteFullAq/{startH}/{startM}/{date}")]
        public void DeleteFullAQ(int startH , int startM , DateTime date)
        {
            data.RemoveFullAvaialableQ(startH , startM , date);
        }
    }
}
