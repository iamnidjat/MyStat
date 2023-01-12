using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStat.Models;
using MyStat.Services;
using MyStat.ViewModels;
using System.Threading.Tasks;

namespace MyStat.Controllers
{
    [Authorize]
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

        [HttpGet]
        public async Task<IActionResult> Add(int userId)
        {
            return View(new UserViewModel
            {
                user = new()
                {
                    Id = userId
                }
            });
        }

        //[HttpPost]
        //public async Task<IActionResult> Add([FromForm] HomeworkItem? item)
        //{
        //    if (item == null || item.Sent < DateTime.Today || item.Title == string.Empty || item.Content == string.Empty)
        //    {
        //        return BadRequest();
        //    }

        //    await _homeworkManager.AddHWAsync(item);

        //    return RedirectToAction("Index", "Homework");
        //}

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] UserViewModel homeworkItem)
        {
            if (homeworkItem == null || homeworkItem.homeWork.Sent < DateTime.Today || homeworkItem.homeWork.Title == string.Empty || homeworkItem.homeWork.Content == string.Empty)
            {
                return BadRequest();
            }

            await _homeworkManager.AddHWAsync(homeworkItem.homeWork);

            return RedirectToAction("Index", "Homework");
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromBody] HomeworkItem? item)
        {
            await _homeworkManager.RemoveHWAsync(item.Id);

            return Ok();
        }

        [HttpGet]
        public IActionResult Remove()
        {
            return View();
        }


        //
        //[HttpGet]
        //public async Task<IActionResult> Get(int? id)
        //{
        //    return View(await _homeworkManager.GetProductByIdAsync(id));
        //}

        [HttpGet]
        public async Task<IActionResult> Download([FromQuery] HomeworkItem? item)
        {
            await _homeworkManager.DownloadHWAsync(item);

            return Ok();
        }
    }
}
