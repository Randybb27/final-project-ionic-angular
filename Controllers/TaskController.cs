using final_project.Models;
using final_project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase 
{
    private readonly ILogger<TaskController> _logger;
    private readonly ITaskRepository _taskRepository;

    public TaskController(ILogger<TaskController> logger, ITaskRepository repository)
    {
        _logger = logger;
        _taskRepository = repository;
    }
    [HttpGet]
public ActionResult<IEnumerable<Tasks>> GetTasks() 
{
    return Ok(_taskRepository.GetTasks());
}

[HttpGet]
[Route("{taskId:int}")]
public ActionResult<Tasks> GetTaskById(int taskId) 
{
    var task = _taskRepository.GetTaskById(taskId);
    if (task == null) {
        return NotFound();
    }
    return Ok(task);
}

[HttpPost]
public ActionResult<Tasks> CreateTask(Tasks task) 
{
    if (!ModelState.IsValid || task == null) {
        return BadRequest();
    }
    var newTask = _taskRepository.CreateTask(task);
    return Created(nameof(GetTaskById), newTask);
}

[HttpPut]
[Route("{taskId:int}")]
public ActionResult<Tasks> UpdateTask(Tasks task) 
{
    if (!ModelState.IsValid || task == null) {
        return BadRequest();
    }
    return Ok(_taskRepository.UpdateTask(task));
}

[HttpDelete]
[Route("{taskId:int}")]
public ActionResult DeleteTask(int taskId) 
{
    _taskRepository.DeleteTaskById(taskId); 
    return NoContent();
}

[HttpPost]
[Route("setComplete/{taskId:int}")]
public ActionResult SetTaskComplete(int taskId)
{
    _taskRepository.SetTaskComplete(taskId);
    return NoContent();

}

[HttpPost]
[Route("setIncomplete/{taskId:int}")]
public ActionResult SetTaskIncomplete(int taskId)
{
    _taskRepository.SetTaskComplete(taskId);
    return NoContent();

}
}