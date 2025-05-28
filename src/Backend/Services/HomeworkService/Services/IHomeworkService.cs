using HomeworkService.DTOs;

namespace HomeworkService.Services;

public interface IHomeworkService
{
    Task<HomeworkResponse> CreateHomeworkAsync(CreateHomeworkRequest request);
    Task<HomeworkResponse?> GetHomeworkByIdAsync(Guid id);
    Task<IEnumerable<HomeworkResponse>> GetHomeworkByClassAsync(Guid classId);
    Task<IEnumerable<HomeworkResponse>> GetHomeworkByTeacherAsync(Guid teacherId);
    Task<HomeworkResponse?> UpdateHomeworkAsync(Guid id, UpdateHomeworkRequest request);
    Task<bool> DeleteHomeworkAsync(Guid id);
    Task<IEnumerable<HomeworkResponse>> GetDueTodayAsync();
    Task<IEnumerable<HomeworkResponse>> GetOverdueAsync();
}
