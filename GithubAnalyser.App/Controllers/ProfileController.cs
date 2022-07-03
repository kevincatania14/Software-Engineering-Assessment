using GithubAnalyser.Models;
using Microsoft.AspNetCore.Mvc;

namespace GithubAnalyser.App.Controllers
{
    public class ProfileController : Controller
    {
        //GET
        public IActionResult Search(GithubProfileCustomModel obj)
        {
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
