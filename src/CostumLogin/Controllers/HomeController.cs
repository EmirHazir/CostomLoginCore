using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CostumLogin.Model;
using Microsoft.AspNetCore.Http;

namespace CostumLogin.Controllers
{
    public class HomeController : Controller
    {
        private OurDbContext _context;
        public HomeController(OurDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.UserAccount.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                _context.UserAccount.Add(user);
                _context.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.Name + "" + user.LastName + "is successfully registered";

            }
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            var account = _context.UserAccount.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("UserId", account.UserId.ToString());
                HttpContext.Session.SetString("UserName", account.UserName);
                return RedirectToAction("Hosgeldin");
            }
            else
            {
                ModelState.AddModelError("", "Username or password is wrong");
            }

            return View();
        }

        public ActionResult Hosgeldin()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                ViewBag.UserName = HttpContext.Session.GetString("Username");
                return View();

            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");

        }

    }
}
