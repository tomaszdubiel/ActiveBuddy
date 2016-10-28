using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SquashLeague.Models;
using SquashLeague.Services;
using SquashLeague.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquashLeague.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private SquashContext _context;

        public AppController(IMailService mailService, IConfigurationRoot config, SquashContext context)
        {
            _mailService = mailService;
            _config = config;
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Trips.ToList();
            return View(data);
        }

        public IActionResult Contact()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if(model.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("Email", "We don't support AOL addresses");
            }

            if(ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From Squash", model.Message);

                ModelState.Clear();

                ViewBag.UserMessage = "Message Sent";
            }
            
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
