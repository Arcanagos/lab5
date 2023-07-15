using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace lab5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private TaskManager manager = new TaskManager();

        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Models.Task> GetAllTasks()
        {
            return manager.GetTasks();
        }
        [HttpGet("{id}")]
        public Models.Task GetTaskById(int id)
        {
            return manager.GetTaskById(id);
        }
        [HttpPost("{title}")]
        public Models.Task CreateTask(string title)
        {
            var newTask = new Models.Task(title);
            manager.AddTask(newTask);
            return newTask;
        }
        [HttpPut("{id},{title}")]
        public bool UpdateTask(int id, string title)
        {
            var newTask = new Models.Task(title);
            manager.UpdateTask(id, newTask);
            return true;
        }
        [HttpDelete("id")]
        public bool DeleteTask(int id)
        {
            return manager.DeleteTask(id);
        }

    }
}