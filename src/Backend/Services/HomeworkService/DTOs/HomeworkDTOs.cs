namespace HomeworkService.DTOs;

public class CreateHomeworkRequest
{
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public Guid ClassId { get; set; }
    public Guid TeacherId { get; set; }
}

public class HomeworkResponse
{
    public Guid Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public Guid ClassId { get; set; }
    public Guid TeacherId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }
}

public class UpdateHomeworkRequest
{
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
}
