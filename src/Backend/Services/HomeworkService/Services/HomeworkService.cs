using HomeworkService.Domain;
using HomeworkService.DTOs;
using HomeworkService.Interfaces;

namespace HomeworkService.Services;

public class HomeworkService : IHomeworkService
{
    private readonly IHomeworkRepository _repository;
    private readonly INotificationService _notificationService;

    public HomeworkService(IHomeworkRepository repository, INotificationService notificationService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
    }

    public async Task<HomeworkResponse> CreateHomeworkAsync(CreateHomeworkRequest request)
    {
        var homework = new Homework(
            request.Subject,
            request.Description,
            request.DueDate,
            request.ClassId,
            request.TeacherId
        );

        var savedHomework = await _repository.AddAsync(homework);
        
        // Benachrichtige alle Schüler der Klasse über neue Hausaufgabe
        await _notificationService.NotifyNewHomework(savedHomework);

        return MapToResponse(savedHomework);
    }

    public async Task<HomeworkResponse?> GetHomeworkByIdAsync(Guid id)
    {
        var homework = await _repository.GetByIdAsync(id);
        return homework != null ? MapToResponse(homework) : null;
    }

    public async Task<IEnumerable<HomeworkResponse>> GetHomeworkByClassAsync(Guid classId)
    {
        var homeworks = await _repository.GetByClassIdAsync(classId);
        return homeworks.Select(MapToResponse);
    }

    public async Task<IEnumerable<HomeworkResponse>> GetHomeworkByTeacherAsync(Guid teacherId)
    {
        var homeworks = await _repository.GetByTeacherIdAsync(teacherId);
        return homeworks.Select(MapToResponse);
    }

    public async Task<HomeworkResponse?> UpdateHomeworkAsync(Guid id, UpdateHomeworkRequest request)
    {
        var homework = await _repository.GetByIdAsync(id);
        if (homework == null)
            return null;

        if (!string.IsNullOrWhiteSpace(request.Description))
            homework.UpdateDescription(request.Description);

        var updated = await _repository.UpdateAsync(homework);
        return MapToResponse(updated);
    }

    public async Task<bool> DeleteHomeworkAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<HomeworkResponse>> GetDueTodayAsync()
    {
        var homeworks = await _repository.GetDueTodayAsync();
        return homeworks.Select(MapToResponse);
    }

    public async Task<IEnumerable<HomeworkResponse>> GetOverdueAsync()
    {
        var homeworks = await _repository.GetOverdueAsync();
        return homeworks.Select(MapToResponse);
    }

    private static HomeworkResponse MapToResponse(Homework homework)
    {
        return new HomeworkResponse
        {
            Id = homework.Id,
            Subject = homework.Subject,
            Description = homework.Description,
            DueDate = homework.DueDate,
            ClassId = homework.ClassId,
            TeacherId = homework.TeacherId,
            CreatedAt = homework.CreatedAt,
            IsCompleted = homework.IsCompleted,
            CompletedAt = homework.CompletedAt
        };
    }
}
