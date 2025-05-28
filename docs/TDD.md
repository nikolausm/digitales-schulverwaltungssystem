# Test-Driven Development (TDD) Dokumentation

## 🧪 TDD-Ansatz

Dieses Projekt folgt strikt dem Test-Driven Development (TDD) Ansatz mit dem Red-Green-Refactor Zyklus:

1. **Red**: Test schreiben, der fehlschlägt
2. **Green**: Minimalen Code schreiben, um den Test zu bestehen
3. **Refactor**: Code verbessern ohne die Tests zu brechen

## 📁 Test-Struktur

```
tests/
├── AuthService.Tests/
│   ├── Domain/          # Domain Model Tests
│   ├── Services/        # Business Logic Tests
│   ├── Controllers/     # API Controller Tests
│   └── Integration/     # Integration Tests
├── HomeworkService.Tests/
│   ├── Domain/
│   ├── Services/
│   ├── Controllers/
│   └── Integration/
└── ...
```

## 🧪 Test-Beispiele

### Unit Tests (Domain)
```csharp
[Fact]
public void CreateHomework_WithValidData_ShouldCreateHomework()
{
    // Arrange
    var subject = "Mathematik";
    var dueDate = DateTime.UtcNow.AddDays(2);
    
    // Act
    var homework = new Homework(subject, description, dueDate, classId, teacherId);
    
    // Assert
    homework.Should().NotBeNull();
    homework.Subject.Should().Be(subject);
}
```

### Service Tests (mit Mocks)
```csharp
[Fact]
public async Task CreateHomework_ShouldNotifyStudents()
{
    // Arrange
    _repositoryMock.Setup(x => x.AddAsync(It.IsAny<Homework>())).ReturnsAsync(homework);
    
    // Act
    await _sut.CreateHomeworkAsync(request);
    
    // Assert
    _notificationServiceMock.Verify(x => x.NotifyNewHomework(It.IsAny<Homework>()), Times.Once);
}
```

## 🏃 Tests ausführen

```bash
# Alle Tests
dotnet test

# Spezifischer Service
dotnet test tests/HomeworkService.Tests

# Mit Coverage
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

# Watch Mode
dotnet watch test
```

## 📊 Test Coverage Ziele

- Domain Models: 100%
- Services: > 90%
- Controllers: > 80%
- Integration: Kritische Pfade

## 🔧 Test Tools

- **xUnit**: Test Framework
- **Moq**: Mocking Framework
- **FluentAssertions**: Readable Assertions
- **WebApplicationFactory**: Integration Tests

## 💡 Best Practices

1. **Arrange-Act-Assert** Pattern verwenden
2. **Ein Konzept pro Test** - Tests klein und fokussiert halten
3. **Aussagekräftige Testnamen** im Format: `MethodName_Scenario_ExpectedBehavior`
4. **Test Isolation** - keine Abhängigkeiten zwischen Tests
5. **Mock external dependencies** - keine echten DB/API Calls in Unit Tests
