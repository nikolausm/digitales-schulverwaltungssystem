using FluentAssertions;
using Xunit;

namespace HomeworkService.Tests.Domain;

public class HomeworkTests
{
    [Fact]
    public void CreateHomework_WithValidData_ShouldCreateHomework()
    {
        // Arrange
        var subject = "Mathematik";
        var description = "Seite 42, Aufgaben 1-5";
        var dueDate = DateTime.UtcNow.AddDays(2);
        var classId = Guid.NewGuid();
        var teacherId = Guid.NewGuid();

        // Act
        var homework = new Homework(subject, description, dueDate, classId, teacherId);

        // Assert
        homework.Should().NotBeNull();
        homework.Id.Should().NotBeEmpty();
        homework.Subject.Should().Be(subject);
        homework.Description.Should().Be(description);
        homework.DueDate.Should().Be(dueDate);
        homework.ClassId.Should().Be(classId);
        homework.TeacherId.Should().Be(teacherId);
        homework.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        homework.IsCompleted.Should().BeFalse();
    }

    [Fact]
    public void CreateHomework_WithEmptySubject_ShouldThrowArgumentException()
    {
        // Arrange
        var description = "Seite 42, Aufgaben 1-5";
        var dueDate = DateTime.UtcNow.AddDays(2);
        var classId = Guid.NewGuid();
        var teacherId = Guid.NewGuid();

        // Act
        var act = () => new Homework("", description, dueDate, classId, teacherId);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("Subject cannot be empty*");
    }

    [Fact]
    public void CreateHomework_WithPastDueDate_ShouldThrowArgumentException()
    {
        // Arrange
        var subject = "Mathematik";
        var description = "Seite 42, Aufgaben 1-5";
        var dueDate = DateTime.UtcNow.AddDays(-1);
        var classId = Guid.NewGuid();
        var teacherId = Guid.NewGuid();

        // Act
        var act = () => new Homework(subject, description, dueDate, classId, teacherId);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("Due date cannot be in the past*");
    }
}
