using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using HomeworkService.Controllers;
using HomeworkService.DTOs;
using HomeworkService.Services;

namespace HomeworkService.Tests.Controllers;

public class HomeworkControllerTests
{
    private readonly Mock<IHomeworkService> _serviceMock;
    private readonly HomeworkController _controller;

    public HomeworkControllerTests()
    {
        _serviceMock = new Mock<IHomeworkService>();
        _controller = new HomeworkController(_serviceMock.Object);
    }

    [Fact]
    public async Task GetHomework_WithValidId_ShouldReturnOk()
    {
        // Arrange
        var homeworkId = Guid.NewGuid();
        var expectedResponse = new HomeworkResponse
        {
            Id = homeworkId,
            Subject = "Englisch",
            Description = "Vocabulary Unit 5"
        };

        _serviceMock
            .Setup(x => x.GetHomeworkByIdAsync(homeworkId))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.GetHomework(homeworkId);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult!.Value.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task GetHomework_WithInvalidId_ShouldReturnNotFound()
    {
        // Arrange
        var homeworkId = Guid.NewGuid();
        _serviceMock
            .Setup(x => x.GetHomeworkByIdAsync(homeworkId))
            .ReturnsAsync((HomeworkResponse?)null);

        // Act
        var result = await _controller.GetHomework(homeworkId);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
}
