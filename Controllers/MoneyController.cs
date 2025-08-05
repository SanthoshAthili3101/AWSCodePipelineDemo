
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AWSCodePipelineDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoneyController : ControllerBase
    {
        private static List<MoneyItem> MoneyRecords = new List<MoneyItem>();
        private static int CurrentId = 1;

        [HttpGet]
        public IEnumerable<MoneyItem> Get()
        {
            return MoneyRecords;
        }

        [HttpPost]
        public IActionResult Post([FromBody] MoneyItem newRecord)
        {
            if (newRecord.Amount <= 0)
            {
                return BadRequest("Amount must be greater than zero.");
            }

            newRecord.Id = CurrentId++;
            MoneyRecords.Add(newRecord);
            return CreatedAtAction(nameof(Get), new { id = newRecord.Id }, newRecord);
        }
    }

    public class MoneyItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}