using API.Core.Entities;
using API.Framework;
using API.Models;
using API.Models.Categories;
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
    [RoutePrefix("api/categories")]
    [Authorize]
    public class CategoryController : BaseApiController
    {
        /// <summary>
        /// Get list Category
        /// </summary>
        /// <remarks>
        /// When user want to get list Category, use this API for getting
        /// </remarks>
        /// <returns></returns>
        [Route("")]
        [SwaggerResponse(200, "Returns the result of get list Category", typeof(CategoryListModel))]
        [SwaggerResponse(500, "Internal Server Error")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult List()
        {
            var model = new CategoryListModel();
            _categoryService.Search("asdf");
            try
            {
                //Get list Category
                var categorys = _categoryService.GetAll();
                //var categorys = db.Categories.ToList();

                if (categorys == null)
                {
                    //not create before
                    model.ErrorMessages.Add("List Category is not found.");
                    return new HttpApiActionResult(HttpStatusCode.BadRequest, model);
                }

                Mapper.Map(categorys, model.CategoryList);


                return new HttpApiActionResult(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                model.ErrorMessages.Add(ex.Message);
                return new HttpApiActionResult(HttpStatusCode.BadRequest, model);
            }
        }

        /// <summary>
        /// Get a Category detail 
        /// </summary>
        /// <remarks>
        /// When user want to get a Category detail, use this API for getting
        /// </remarks>
        /// <param name="id">Category identity</param>
        /// <returns></returns>
        //[Route("{id}")]
        //[SwaggerResponse(200, "Returns the result of get a Category detail", typeof(CategoryDetailModel))]
        //[SwaggerResponse(500, "Internal Server Error")]
        //[SwaggerResponse(400, "Bad Request")]
        //[SwaggerResponse(401, "Not Authorizated")]
        //[HttpGet]
        //public IHttpActionResult Detail(int id)
        //{
        //    //var category = _categoryService.GetById(id);
        //    var category = db.Categories.FirstOrDefault(x => x.Id == id); ;

        //    var model = new CategoryDetailModel();
        //    if (category == null)
        //    {
        //        model.ErrorMessages.Add("Can not find Category.");
        //        return new HttpApiActionResult(HttpStatusCode.BadRequest, model);
        //    }

        //    Mapper.Map(category, model);

        //    model.Messages = new List<string> { "Successful!" };

        //    return new HttpApiActionResult(HttpStatusCode.OK, model);
        //}

        /// <summary>
        /// Add a Category
        /// </summary>
        /// <remarks>
        /// When user want to add a Category, use this API for getting
        /// </remarks>
        /// <returns></returns>
        //[Route("")]
        //[SwaggerResponse(200, "Returns the result of add a Category", typeof(ApiJsonResult))]
        //[SwaggerResponse(500, "Internal Server Error")]
        //[SwaggerResponse(400, "Bad Request")]
        //[SwaggerResponse(401, "Not Authorizated")]
        //[HttpPost]
        //public IHttpActionResult Add(CategoryEditModel model)
        //{
        //    var res = new ApiJsonResult();

        //    try
        //    {
        //        //Check is valid
        //        if (!ModelState.IsValid)
        //        {
        //            res.ErrorMessages.AddRange(ModelState.ToListErrorMessage());
        //            return new HttpApiActionResult(HttpStatusCode.BadRequest, res);
        //        }

        //        //Create Category
        //        var category = Mapper.Map<CategoryEditModel, Category>(model);

        //        //Save to database
        //        _categoryService.Insert(category);

        //        return new HttpApiActionResult(HttpStatusCode.OK, res);
        //    }
        //    catch (Exception ex)
        //    {
        //        res.ErrorMessages.Add(ex.Message);
        //        return new HttpApiActionResult(HttpStatusCode.BadRequest, res);
        //    }
        //}

        /// <summary>
        /// Update a Category
        /// </summary>
        /// <remarks>
        /// When user want to update a Category, use this API for getting
        /// </remarks>
        /// <returns></returns>
        //[Route("")]
        //[SwaggerResponse(200, "Returns the result of update a Category", typeof(ApiJsonResult))]
        //[SwaggerResponse(500, "Internal Server Error")]
        //[SwaggerResponse(400, "Bad Request")]
        //[SwaggerResponse(401, "Not Authorizated")]
        //[HttpPut]
        //public IHttpActionResult Update(CategoryEditModel model)
        //{
        //    var res = new ApiJsonResult();

        //    try
        //    {
        //        //Check data is valid
        //        if (!ModelState.IsValid)
        //        {
        //            res.ErrorMessages.AddRange(ModelState.ToListErrorMessage());
        //            return new HttpApiActionResult(HttpStatusCode.BadRequest, res);
        //        }
        //        //Get Category by identity
        //        var category = _categoryService.GetById(model.Id);
        //        if (category == null)
        //        {
        //            res.ErrorMessages.Add("Category is not found.");
        //            return Json(res);
        //        }

        //        //Update Category
        //        Mapper.Map(model, category);

        //        //update
        //        _categoryService.Update(category);

        //        return new HttpApiActionResult(HttpStatusCode.OK, res);
        //    }
        //    catch (Exception ex)
        //    {
        //        res.ErrorMessages.Add(ex.Message);
        //        return new HttpApiActionResult(HttpStatusCode.BadRequest, res);
        //    }
        //}

        /// <summary>
        /// Delete a Category
        /// </summary>
        /// <remarks>
        /// When user want to delete a Category, use this API for getting<br/>
        /// </remarks>
        /// <param name="id">Category identity</param>
        /// <returns></returns>
        //[Route("{id}")]
        //[SwaggerResponse(200, "Returns the result of delete a Category", typeof(ApiJsonResult))]
        //[SwaggerResponse(500, "Internal Server Error")]
        //[SwaggerResponse(400, "Bad Request")]
        //[SwaggerResponse(401, "Not Authorizated")]
        //[HttpDelete]
        //public IHttpActionResult Delete(int id)
        //{
        //    var res = new ApiJsonResult();

        //    try
        //    {
        //        //Get Category by identity
        //        var category = _categoryService.GetById(id);
        //        if (category == null)
        //        {
        //            res.ErrorMessages.Add("Category is not found.");
        //            return new HttpApiActionResult(HttpStatusCode.BadRequest, res);
        //        }

        //        _categoryService.Delete(category);

        //        return new HttpApiActionResult(HttpStatusCode.OK, res);
        //    }
        //    catch (Exception ex)
        //    {
        //        res.ErrorMessages.Add("Can not delete Category.");
        //        return new HttpApiActionResult(HttpStatusCode.BadRequest, res);
        //    }
        //}
    }
}