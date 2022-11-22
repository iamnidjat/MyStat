using MyStat.Models;

namespace MyStat.Services
{
    public interface IHomeworkManager : IEnumerable<HomeworkItem>
    {
        Task<bool> AddHWAsync(HomeworkItem homeworkItem);
        Task<bool> RemoveHWAsync(int? id);
        Task<HomeworkItem?> GetProductByIdAsync(int? id);
        Task DownloadHWAsync(string? path, HomeworkItem homeworkItem);
    }
}
