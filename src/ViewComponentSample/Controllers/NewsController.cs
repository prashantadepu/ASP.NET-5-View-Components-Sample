using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ViewComponentSample.Controllers
{
    public class NewsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TechNews()
        {
            ViewBag.Message = "Technology News Page.";
            return View();
        }

        public IActionResult PoliticalNews()
        {
            ViewBag.Message = "Political News Page.";
            return View();
        }

        public IActionResult SportsNews()
        {
            ViewBag.Message = "Sports News Page.";
            return View();
        }
    }
}
