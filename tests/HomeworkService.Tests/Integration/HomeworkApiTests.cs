using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Xunit;
using HomeworkService.DTOs;

namespace HomeworkService.Tests.Integration;

public class HomeworkApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public HomeworkApiTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task CreateHomework_ShouldReturnCreatedStatus()
    {
        // Arrange
        var request = new CreateHomeworkRequest
        {
            Subject = "Biologie",
            Description = "Referat über Photosynthese vorbereiten",
            DueDate = DateTime.UtcNow.AddDays(7),
            ClassId = Guid.NewGuid(),
            TeacherId = Guid.NewGuid()
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/homework", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var createdHomework = await response.Content.ReadFromJsonAsync<HomeworkResponse>();
        createdHomework.Should().NotBeNull();
        createdHomework!.Subject.Should().Be(request.Subject);
        createdHomework.Description.Should().Be(request.Description);
    }

    [Fact]
    public async Task GetHomework_WithInvalidId_ShouldReturnNotFound()
    {
        // Arrange
        var invalidId = Guid.NewGuid();

        // Act
        var response = await _client.GetAsync($"/api/homework/{invalidId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
