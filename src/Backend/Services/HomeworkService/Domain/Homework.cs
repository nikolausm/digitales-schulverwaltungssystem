namespace HomeworkService.Domain;

public class Homework
{
    public Guid Id { get; private set; }
    public string Subject { get; private set; }
    public string Description { get; private set; }
    public DateTime DueDate { get; private set; }
    public Guid ClassId { get; private set; }
    public Guid TeacherId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    public Homework(string subject, string description, DateTime dueDate, Guid classId, Guid teacherId)
    {
        if (string.IsNullOrWhiteSpace(subject))
            throw new ArgumentException("Subject cannot be empty", nameof(subject));
        
        if (dueDate <= DateTime.UtcNow)
            throw new ArgumentException("Due date cannot be in the past", nameof(dueDate));
        
        Id = Guid.NewGuid();
        Subject = subject;
        Description = description;
        DueDate = dueDate;
        ClassId = classId;
        TeacherId = teacherId;
        CreatedAt = DateTime.UtcNow;
        IsCompleted = false;
    }

    public void MarkAsCompleted()
    {
        if (IsCompleted)
            throw new InvalidOperationException("Homework is already completed");
            
        IsCompleted = true;
        CompletedAt = DateTime.UtcNow;
    }

    public void UpdateDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
            throw new ArgumentException("Description cannot be empty", nameof(newDescription));
            
        Description = newDescription;
    }
}
