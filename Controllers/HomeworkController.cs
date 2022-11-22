using Microsoft.AspNetCore.Mvc;
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

            await _homeworkManager.AddHWAsync(item);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Remove(int? id)
        {
            if (HttpContext.Request.Method == HttpMethod.Get.Method || id == null)
            {
                return View();
            }

            await _homeworkManager.RemoveHWAsync((int)id);

            return RedirectToAction("Index");
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
