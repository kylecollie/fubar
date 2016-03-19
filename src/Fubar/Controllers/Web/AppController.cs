using Fubar.Models;
using Fubar.Services;
using Fubar.ViewModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Fubar.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IFubarRepository _repository;

        public AppController(IMailService service, IFubarRepository repository)
        {
            _mailService = service;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var tickets = _repository.GetAllTickets();
            //var tickets = _repository.GetAllTicketsUnresolved();
            //var tickets = _repository.GetAllTicketsResolved();
            return View(tickets);
        }

        [Authorize]
        public IActionResult Ticket()
        {
            return View();
        }

        [Authorize]
        public IActionResult Admin()
        {
            var products = _repository.GetAllProducts();
            //return View(products);
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];

                if (string.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "Could not send email, configuration problem.");
                }

                if (_mailService.SendMail(email,
                    email,
                    $"Contact Page from {model.Name} ({model.Email})",
                    model.Message))
                {
                    ModelState.Clear();

                    ViewBag.Message = "Mail sent. Thanks!";

                }
            }
            return View();

        }
    }
}