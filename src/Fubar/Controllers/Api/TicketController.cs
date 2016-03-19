using AutoMapper;
using Fubar.Models;
using Fubar.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace Fubar.Controllers.Api
{
    [Route("api/tickets")]
    public class TicketController : Controller
    {
        private ILogger<TicketController> _logger;
        private IFubarRepository _repository;

        public TicketController(IFubarRepository repository, ILogger<TicketController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var results = Mapper.Map<IEnumerable<TicketViewModel>>(_repository.GetAllTickets());

            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]TicketViewModel vm)
        {
            var _userId = User.GetUserId();
            var _userName = User.GetUserName();
            try
            {
                if (ModelState.IsValid)
                {
                    var newTicket = Mapper.Map<Ticket>(vm);
                    newTicket.UserName = _userName;

                    // Save to Database
                    _logger.LogInformation("Attempting to save a new ticket.");
                    _repository.AddTicket(newTicket);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<TicketViewModel>(newTicket));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new ticket.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }
            
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}

// https://app.pluralsight.com/player?course=aspdotnet-5-ef7-bootstrap-angular-web-app&author=shawn-wildermuth&name=aspdotnet-5-ef7-bootstrap-angular-web-app-m7&clip=3&mode=live ... 0:19