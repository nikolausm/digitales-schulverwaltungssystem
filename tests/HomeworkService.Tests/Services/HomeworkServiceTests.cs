using FluentAssertions;
using Moq;
using Xunit;

namespace HomeworkService.Tests.Services;

public class HomeworkServiceTests
{
    private readonly Mock<IHomeworkRepository> _repositoryMock;
    private readonly Mock<INotificationService> _notificationServiceMock;
    private readonly HomeworkService _sut; // System Under Test

    public HomeworkServiceTests()
    {
        _repositoryMock = new Mock<IHomeworkRepository>();
        _notificationServiceMock = new Mock<INotificationService>();
        _sut = new HomeworkService(_repositoryMock.Object, _notificationServiceMock.Object);
    }

    [Fact]
    public async Task CreateHomework_WithValidData_ShouldCreateAndNotify()
    {
        // Arrange
        var request = new CreateHomeworkRequest
        {
            Subject = "Deutsch",
            Description = "Aufsatz über Sommerferien",
            DueDate = DateTime.UtcNow.AddDays(3),
            ClassId = Guid.NewGuid(),
            TeacherId = Guid.NewGuid()
        };

        _repositoryMock
            .Setup(x => x.AddAsync(It.IsAny<Homework>()))
            .ReturnsAsync((Homework h) => h);

        // Act
        var result = await _sut.CreateHomeworkAsync(request);

        // Assert
        result.Should().NotBeNull();
        result.Subject.Should().Be(request.Subject);
        
        _repositoryMock.Verify(x => x.AddAsync(It.IsAny<Homework>()), Times.Once);
        _notificationServiceMock.Verify(x => x.NotifyNewHomework(It.IsAny<Homework>()), Times.Once);
    }
}
