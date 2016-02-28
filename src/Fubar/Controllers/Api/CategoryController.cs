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
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private ILogger<CategoryController> _logger;
        private ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository, ILogger<CategoryController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            try
            {
                var results = Mapper.Map<IEnumerable<CategoryViewModel>>(_repository.GetAllCategories());
                if (results == null)
                {
                    return Json(null);
                }

                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get all categories", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occurred finding all categories.");
            }
        }


    }
}
