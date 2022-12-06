using MyStat.Models;

namespace MyStat.Services
{
    public interface IHomeworkManager : IEnumerable<HomeworkItem>
    {
        Task AddHWAsync(HomeworkItem homeworkItem);
        Task RemoveHWAsync(int? id);
        Task<HomeworkItem?> GetProductByIdAsync(int? id);
        Task DownloadHWAsync(HomeworkItem homeworkItem);
    }
}
