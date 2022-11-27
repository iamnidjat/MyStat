﻿using Microsoft.AspNetCore.Mvc;
using MyStat.Models;
using MyStat.Services;

namespace MyStat.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly IHomeworkManager _homeworkManager;

        public HomeworkController(IHomeworkManager homeworkManager)
        {
            _homeworkManager = homeworkManager;
        }

        public IActionResult Index()
        {
            return View(_homeworkManager);
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Add([FromForm] HomeworkItem? item)
        {
            if (HttpContext.Request.Method == HttpMethod.Get.Method || item == null)
            {
                return View();
            }

            if (item.Sent < DateTime.Today || item.Title == string.Empty || item.Content == string.Empty)
            {
                return View();
            }

            await _homeworkManager.AddHWAsync(item);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int? id)
        {
            await _homeworkManager.RemoveHWAsync(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? id)
        {
            return View(await _homeworkManager.GetProductByIdAsync(id));
        }

        [HttpGet]
        public async Task Download(string? path, [FromForm] HomeworkItem? item)
        {
            await _homeworkManager.DownloadHWAsync(path, item);
        }
    }
}
