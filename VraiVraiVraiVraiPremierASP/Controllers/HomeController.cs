using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VraiVraiVraiVraiPremierASP.Data;
using VraiVraiVraiVraiPremierASP.Models;

namespace VraiVraiVraiVraiPremierASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _context.Personnes.Load();
        }

        public IActionResult Index()
        {
            return View("Index", _context.Personnes.ToList());
        }

        public IActionResult Add()
        {
            return View("Add");
        }

        public IActionResult Detail(int id)
        {
            return View("Detail", _context.Personnes.First(x => x.Id == id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Add(Personne personne)
        {
            _context.Personnes.Add(personne);
            _context.SaveChanges();
            return View("Index", _context.Personnes.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}