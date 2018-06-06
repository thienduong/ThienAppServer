using API.Models;
using AutoMapper;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        /// <summary>
        /// Get list Product
        /// </summary>
        /// <remarks>
        /// When user want to get list Product, use this API for getting
        /// </remarks>
        /// <returns></returns>
        [Route("")]
        [SwaggerResponse(200, "Returns the result of get list Product", typeof(ProductListModel))]
        [SwaggerResponse(500, "Internal Server Error")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult List()
        {
            var model = new ProductListModel();
            
            try
            {
                //Get list Product
                //var products = _productService.GetAll();
                var products = db.Products.ToList();

                if (products == null)
                {
                    //not create before
                    model.ErrorMessages.Add("List Product is not found.");
                    return Json(model);
                }

                Mapper.Map(products, model.ProductList);
                return Json(model);
            }
            catch (Exception ex)
            {
                //_logger.Error("Product list api got error", ex);
                model.ErrorMessages.Add(ex.Message);
                return Json(model);
            }
        }
    }
}
