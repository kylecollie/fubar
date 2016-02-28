﻿using AutoMapper;
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
    [Route("api/severities")]
    public class SeverityController : Controller
    {
        private ILogger<SeverityController> _logger;
        private ISeverityRepository _repository;

        public SeverityController(ISeverityRepository repository, ILogger<SeverityController> logger )
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            try
            {
                var results = Mapper.Map<IEnumerable<SeverityViewModel>>(_repository.GetAllSeverities());
                if (results == null)
                {
                    return Json(null);
                }
                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get severties.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occurred finding all severities.");
            }
        }
    }
}
