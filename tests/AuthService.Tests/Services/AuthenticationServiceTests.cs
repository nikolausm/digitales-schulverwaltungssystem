using FluentAssertions;
using Moq;
using Xunit;
using AuthService.Services;
using AuthService.Models;
using AuthService.Interfaces;
using Microsoft.Extensions.Options;

namespace AuthService.Tests.Services;

public class AuthenticationServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<ITokenService> _tokenServiceMock;
    private readonly Mock<IPasswordHasher> _passwordHasherMock;
    private readonly Mock<IOptions<JwtSettings>> _jwtSettingsMock;
    private readonly AuthenticationService _sut;

    public AuthenticationServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _tokenServiceMock = new Mock<ITokenService>();
        _passwordHasherMock = new Mock<IPasswordHasher>();
        _jwtSettingsMock = new Mock<IOptions<JwtSettings>>();
        
        _jwtSettingsMock.Setup(x => x.Value).Returns(new JwtSettings
        {
            Secret = "SuperSecretKeyForTesting123456789",
            Issuer = "TestIssuer",
            Audience = "TestAudience",
            ExpiryMinutes = 60
        });

        _sut = new AuthenticationService(
            _userRepositoryMock.Object,
            _tokenServiceMock.Object,
            _passwordHasherMock.Object,
            _jwtSettingsMock.Object
        );
    }

    [Fact]
    public async Task Login_WithValidCredentials_ShouldReturnToken()
    {
        // Arrange
        var username = "lehrer@schule.de";
        var password = "password123";
        var hashedPassword = "hashedPassword";
        var expectedToken = "valid.jwt.token";
        
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Email = username,
            PasswordHash = hashedPassword,
            Role = UserRole.Teacher
        };

        _userRepositoryMock
            .Setup(x => x.GetByUsernameAsync(username))
            .ReturnsAsync(user);
            
        _passwordHasherMock
            .Setup(x => x.VerifyPassword(password, hashedPassword))
            .Returns(true);
            
        _tokenServiceMock
            .Setup(x => x.GenerateToken(It.IsAny<User>()))
            .Returns(expectedToken);

        // Act
        var result = await _sut.LoginAsync(username, password);

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Token.Should().Be(expectedToken);
        result.User.Should().NotBeNull();
        result.User!.Username.Should().Be(username);
    }
}
