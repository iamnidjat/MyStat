﻿using Microsoft.EntityFrameworkCore;
using MyStat.Models;
using System.Collections;

namespace MyStat.Services
{
    public class HomeworkManager : IHomeworkManager
    {
        private readonly MyStatDbContext _myStatDbContext;

        public HomeworkManager(MyStatDbContext myStatDbContext)
        {
            _myStatDbContext = myStatDbContext;
        }

        public async Task<bool> AddHWAsync(HomeworkItem homeworkItem)
        {
            try
            {
                await _myStatDbContext.Homeworks.AddAsync(homeworkItem);
                await _myStatDbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
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

        public async Task<bool> RemoveHWAsync(int? id)
        {
            try
            {
                var result = await GetProductByIdAsync(id);

                if (result != null)
                {
                    _myStatDbContext.Homeworks.Remove(result);

                    await _myStatDbContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }

            catch
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}