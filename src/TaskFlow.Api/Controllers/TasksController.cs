using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.Models;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> Tasks = new()
    {
        new TaskItem
        {
            Id = 1,
            Title = "Learn Git",
            IsCompleted = true
        },
        new TaskItem
        {
            Id = 2,
            Title = "Learn .NET API",
            IsCompleted = false
        }
    };

    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok(Tasks);
    }

    [HttpGet("{id}")]
    public IActionResult GetTaskById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Id must be greater than 0.");
        }

        var task = Tasks.FirstOrDefault(task => task.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPost]
    public IActionResult CreateTask(TaskItem newTask)
    {
        newTask.Id = Tasks.Count + 1;

        Tasks.Add(newTask);

        return Ok(newTask);
    }
}