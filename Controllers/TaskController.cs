
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AWSCodePipelineDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private static List<TaskItem> Tasks = new List<TaskItem>();
        private static int CurrentId = 1;

        [HttpGet]
        public IEnumerable<TaskItem> Get()
        {
            return Tasks;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskItem newTask)
        {
            if (string.IsNullOrEmpty(newTask.Name))
            {
                return BadRequest("Task name is required.");
            }

            newTask.Id = CurrentId++;
            Tasks.Add(newTask);
            return CreatedAtAction(nameof(Get), new { id = newTask.Id }, newTask);
        }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}