﻿using AutoMapper;
using Fubar.Models;
using Fubar.ViewModels;
using Microsoft.AspNet.Authorization;
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
        private IFubarRepository _repository;

        public ProductController(IFubarRepository repository, ILogger<ProductController> logger)
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

        [HttpGet("{id:int}")]
        public JsonResult Get(int id)
        {
            try
            {
                var results = Mapper.Map<ProductViewModel>(_repository.GetProductById(id));
                if (results == null)
                {
                    return Json(null);
                }

                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get product.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occurred finding product.");
            }
        }

        [HttpPut("")]
        public JsonResult Put([FromBody]ProductViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Map to entity
                    var updateProduct = Mapper.Map<Product>(vm);
                    // Save to database
                    _repository.UpdateProduct(updateProduct);
                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.OK;
                        return Json(Mapper.Map<ProductViewModel>(updateProduct));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to update product.", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed to update product.");
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Validation failed on product.");
        }

        [Authorize]
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
