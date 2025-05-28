using HomeworkService.Domain;

namespace HomeworkService.Interfaces;

public interface IHomeworkRepository
{
    Task<Homework> AddAsync(Homework homework);
    Task<Homework?> GetByIdAsync(Guid id);
    Task<IEnumerable<Homework>> GetByClassIdAsync(Guid classId);
    Task<IEnumerable<Homework>> GetByTeacherIdAsync(Guid teacherId);
    Task<Homework> UpdateAsync(Homework homework);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Homework>> GetDueTodayAsync();
    Task<IEnumerable<Homework>> GetOverdueAsync();
}

public interface INotificationService
{
    Task NotifyNewHomework(Homework homework);
    Task NotifyHomeworkDueSoon(Homework homework);
    Task NotifyHomeworkOverdue(Homework homework);
}
