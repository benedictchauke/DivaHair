using DivaHair.Data;
using DivaHair.Services;
using DivaHair.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivaHair.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly HairContext _context;

        public AppController(IMailService mailService, HairContext context)
        {
            _mailService = mailService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //send the email
                _mailService.SendMessage("benedictchauke@hotmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UseMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                //show an error
            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            /* var results = _context.Products
                .OrderBy(p => p.Category)
                .ToList();
            return View(); */

            var results = from p in _context.Products
                          orderby p.Category
                          select p;
            return View(results.ToList());
 
        }
    }
}
