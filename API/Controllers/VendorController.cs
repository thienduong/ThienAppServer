﻿using API.Core.Entities;
using API.Framework;
using API.Models;
using API.Models.Categories;
using API.Models.Vendors;
using AutoMapper;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    /// <summary>
    /// Category Api
    /// </summary>
    [RoutePrefix("api/vendor")]
    public class VendorController : BaseApiController
    {
        /// <summary>
        /// Get list Category
        /// </summary>
        /// <remarks>
        /// When user want to get list Category, use this API for getting
        /// </remarks>
        /// <returns></returns>
        [Route("")]
        [SwaggerResponse(200, "Returns the result of get list Vendor", typeof(VendorListModel))]
        [SwaggerResponse(500, "Internal Server Error")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult List()
        {
            var model = new VendorListModel();
           
            try
            {
                //Get list Category
                var vendors = _vendorService.GetAll();
                //var vendors = db.Categories.ToList();

                if (vendors == null)
                {
                    //not create before
                    model.ErrorMessages.Add("List Vendor is not found.");
                    return new HttpApiActionResult(HttpStatusCode.BadRequest, model);
                }

                Mapper.Map(vendors, model.VendorList);


                return new HttpApiActionResult(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                model.ErrorMessages.Add(ex.Message);
                return new HttpApiActionResult(HttpStatusCode.BadRequest, model);
            }
        }

    
    }
}