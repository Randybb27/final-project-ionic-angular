using final_project.Models;

namespace final_project.Repositories;

public interface ITaskRepository {
    IEnumerable<Tasks> GetTasks();
    Tasks? GetTaskById(int taskId);
    Tasks CreateTask(Tasks newTask);
    Tasks? UpdateTask(Tasks newTask);
    void DeleteTaskById(int taskId);
    void SetTaskComplete(int taskId);
    void SetTaskIncomplete(int taskId);

}


