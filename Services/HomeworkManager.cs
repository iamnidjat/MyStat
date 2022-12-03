using Microsoft.EntityFrameworkCore;
using MyStat.Models;
using System.Collections;
using System.IO;

namespace MyStat.Services
{
    public class HomeworkManager : IHomeworkManager
    {
        private readonly MyStatDbContext _myStatDbContext;

        public HomeworkManager(MyStatDbContext myStatDbContext)
        {
            _myStatDbContext = myStatDbContext;
        }

        public async Task AddHWAsync(HomeworkItem homeworkItem)
        {
            await _myStatDbContext.Homeworks.AddAsync(homeworkItem);
            await _myStatDbContext.SaveChangesAsync();
        }

        public IEnumerator<HomeworkItem> GetEnumerator()
        {
            foreach (var item in _myStatDbContext.Homeworks)
            {
                yield return item;
            }
        }

        public async Task<HomeworkItem?> GetProductByIdAsync(int? id)
        {

            if (id == null)
            {
                return null;
            }

            return await _myStatDbContext.Homeworks.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveHWAsync(int? id)
        {
            var result = await GetProductByIdAsync(id);

            if (result != null)
            {
                _myStatDbContext.Homeworks.Remove(result);

                await _myStatDbContext.SaveChangesAsync();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public async Task DownloadHWAsync(string? path, HomeworkItem homeworkItem)
        {
            using (StreamWriter writer = new(path + ".txt", true))
            {
                await writer.WriteAsync($"Title: {homeworkItem.Title}\n\nContent:\n{homeworkItem.Content}\n\nUpload date: {homeworkItem.Sent}");
            }
        }
    }
}
