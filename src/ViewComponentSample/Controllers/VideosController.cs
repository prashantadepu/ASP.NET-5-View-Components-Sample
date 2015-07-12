using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ViewComponentSample.Controllers
{
    public class VideosController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LatestVideos()
        {
            ViewBag.Message = "Latest Videos Page.";
            return View();
        }

        public IActionResult MustWatchVideos()
        {
            ViewBag.Message = "Must Watch Videos Page.";
            return View();
        }
    }
}
