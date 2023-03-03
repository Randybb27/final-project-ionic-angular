using System.ComponentModel.DataAnnotations;

namespace final_project.Models;

public class Tasks
{
    public int TaskId { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public bool Completed { get; set; }
}
