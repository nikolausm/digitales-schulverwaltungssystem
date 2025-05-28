namespace Shared.Models;

public enum UserRole
{
    Student,
    Teacher,
    Parent,
    Administrator
}

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
}

public class Homework
{
    public Guid Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public Guid ClassId { get; set; }
    public Guid TeacherId { get; set; }
    public DateTime CreatedAt { get; set; }
}
