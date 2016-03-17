using AutoMapper;
using Fubar.Models;
using Fubar.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Fubar.Controllers.Api
{
    [Route("api/priorities")]
    public class PriorityController : Controller
    {
        private ILogger<PriorityController> _logger;
        private IFubarRepository _repository;

        public PriorityController(IFubarRepository repository, ILogger<PriorityController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            try
            {
                var results = Mapper.Map<IEnumerable<PriorityViewModel>>(_repository.GetAllPriorities());
                if (results == null)
                {
                    return Json(null); 
                }

                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get priorities.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occurred finding all priorities.");
            }
        }
    }
}
