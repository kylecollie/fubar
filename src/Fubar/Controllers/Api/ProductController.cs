using AutoMapper;
using Fubar.Models;
using Fubar.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace Fubar.Controllers.Api
{
    [Route("api/products")]
    public class ProductController : Controller
    {
        private ILogger<ProductController> _logger;
        private IProductRepository _repository;

        public ProductController(IProductRepository repository, ILogger<ProductController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            try
            {
                var results = Mapper.Map<IEnumerable<ProductViewModel>>(_repository.GetAllProducts());
                if (results == null)
                {
                    return Json(null);
                }

                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get products.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occurred finding all products.");
            }
        }

        public JsonResult Post([FromBody]ProductViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Map to Entity
                    var newProduct = Mapper.Map<Product>(vm);
                    // Save to Database
                    _repository.AddProduct(newProduct);
                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<ProductViewModel>(newProduct));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new product.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed to save new product.");
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Validation failed on new product.");
        }


    }
}
