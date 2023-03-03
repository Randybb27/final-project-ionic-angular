using MySql.Data.MySqlClient;
using final_project.Models;

namespace final_project.Repositories;

public class SqlJobRepository : ITaskRepository
{
    private static string _myConnectionString = "server=127.0.0.1;uid=root;pwd=Password1!;database=mydb";

  
      public void SetTaskIncomplete(int taskId)
    {
        var conn = new MySql.Data.MySqlClient.MySqlConnection(_myConnectionString);
        conn.Open();
string query = $"UPDATE Tasks set Complete = 0 WHERE taskId = {taskId}";

        var command = new MySqlCommand(query, conn);

        // command.Parameters.AddWithValue(parameterName: "@id", taskId);
        command.Prepare();

        command.ExecuteNonQuery();

        conn.Close();

    }
    public void SetTaskComplete(int taskId)
    {
        var conn = new MySql.Data.MySqlClient.MySqlConnection(_myConnectionString);
        conn.Open();
        string query = $"UPDATE Tasks set Complete = 1 WHERE taskId = @taskId;";
        var command = new MySqlCommand(query, conn);

        command.Parameters.AddWithValue(parameterName: "@id", taskId);
        command.Prepare();

        command.ExecuteNonQuery();

        conn.Close();

    }

    public Tasks CreateTask(Tasks newTitle)
    {
        var conn = new MySql.Data.MySqlClient.MySqlConnection(_myConnectionString);
        conn.Open();


        string query = $"INSERT INTO tasks (Title) VALUES ('{newTitle.Title}');";
        var command = new MySqlCommand(query, conn);

    
        command.Prepare();

        command.ExecuteNonQuery();
        int id = (int)command.LastInsertedId;
        conn.Close();


        return null;
    }
   
    public void DeleteTaskById(int taskId)
      {
        var conn = new MySql.Data.MySqlClient.MySqlConnection(_myConnectionString);
        conn.Open();

        string query = "DELETE FROM  WHERE taskId = @id;";
        var command = new MySqlCommand(query, conn);

        command.Parameters.AddWithValue(parameterName: "@id", taskId);
        command.Prepare();

        command.ExecuteNonQuery();

        conn.Close();
    }

       public Tasks? GetTaskById(int taskId)
  {
        Tasks task = null;

        var conn = new MySql.Data.MySqlClient.MySqlConnection(_myConnectionString);
        conn.Open();

        string query = "SELECT * FROM task WHERE taskId = @id;";
        var command = new MySqlCommand(query, conn);

        command.Parameters.AddWithValue(parameterName: "@id", taskId);
        command.Prepare();

        var reader = command.ExecuteReader();

        reader.Read();

        if (reader.HasRows)
        {
            task = new Tasks
            {
                TaskId = reader.GetInt32(column: "taskId"),
                
            };
        }

        reader.Close();
        conn.Close();

        return task;
    }

    public IEnumerable<Tasks> GetTasks()
       {
        var taskList = new List<Tasks>();

        var conn = new MySql.Data.MySqlClient.MySqlConnection(_myConnectionString);
        conn.Open();

        string query = "SELECT * FROM tasks;";
        var command = new MySqlCommand(query, conn);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            taskList.Add(new Tasks
            {
                TaskId = reader.GetInt32(column: "taskId"),
                Title = reader.GetString(column: "Title"),
                
            });
        }

        reader.Close();
        conn.Close();

        return taskList;
    }
   
    public Tasks? UpdateTask(Tasks newTitle)
      {
        var conn = new MySql.Data.MySqlClient.MySqlConnection(_myConnectionString);
        conn.Open();

        string query = "UPDATE task SET Title = @Title" +
            "WHERE taskId = @id";
        var command = new MySqlCommand(query, conn);

        command.Parameters.AddWithValue(parameterName: "@Title", newTitle.Title);
        
        command.Prepare();

        command.ExecuteNonQuery();

        conn.Close();

        return newTitle;
    }
}