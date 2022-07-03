using GithubAnalyser.App.Models;
using GithubAnalyser.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using GithubAnalyser.Models;
using System.Diagnostics;

namespace GithubAnalyser.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProfileSearchVM obj)
        {
            //creating guid for log reference
            Guid reference = Guid.NewGuid();
            Logging.Log.Logger.Info("Ref: {0}; Username: {1}; State: New request", reference, obj.username);

            if (ModelState.IsValid)
            {
                Logging.Log.Logger.Info("Ref: {0}; Username: {1}; State: Started analysing", reference, obj.username);

                //searching for github profile passed as parameter
                GithubAnalyser.BusinessLogic.GithubAnalyser bl = new GithubAnalyser.BusinessLogic.GithubAnalyser();
                GithubProfileCustomModel profile = bl.Analyse(obj.username);

                Logging.Log.Logger.Info("Ref: {0}; Username: {1}; State: Finished analysing; " +
                    "Login: {2}; Company: {3}; Location: {4}; Public_repos: {5}; Message: {6}",
                    reference, obj.username, profile.company, profile.location, profile.public_repos, profile.following, profile.message);

                //returning json response
                //return View(obj);
                return RedirectToAction("Search", "Profile", profile);
            }

            Logging.Log.Logger.Warn("Ref: {0}; Username: {1}; State: Failed immediately", reference, obj.username);

            return View(obj);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}