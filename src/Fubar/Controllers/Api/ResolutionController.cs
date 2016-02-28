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
    [Route("api/resolutions")]
    public class ResolutionController : Controller
    {
        private ILogger<ResolutionController> _logger;
        private IResolutionRepository _repository;

        public ResolutionController(IResolutionRepository repository, ILogger<ResolutionController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            try
            {
                var results = Mapper.Map<IEnumerable<ResolutionViewModel>>(_repository.GetAllResolutions());
                if (results == null)
                {
                    return Json(null);
                }
                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get resolutions.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occurred finding all resolutions.");
            }
        }
    }
}
