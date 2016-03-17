using AutoMapper;
using Fubar.Models;
using Fubar.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
namespace Fubar.Controllers.Api
{
    [Route("api/statuses")]
    public class StatusController : Controller
    {
        private ILogger<StatusController> _logger;
        private IFubarRepository _repository;

        public StatusController(IFubarRepository repository, ILogger<StatusController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            try
            {
                var results = Mapper.Map<IEnumerable<StatusViewModel>>(_repository.GetAllStatuses());
                if (results == null)
                {
                    return Json(null);
                }
                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get statuses.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occurred finding all statuses.");
            }
        }
    }
}
