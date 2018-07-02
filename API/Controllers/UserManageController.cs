using API.Framework;
using API.Models.Users;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace API.Controllers
{
    [RoutePrefix("api/users")]
    public class UserManageController : BaseApiController
    {     
        private ApplicationUserManager _userManager;
        public UserManageController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
          
        }
        public UserManageController()
        {
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [Route("")]
        [SwaggerResponse(200, "Returns the result of get list Vendor", typeof(UserListModel))]
        [SwaggerResponse(500, "Internal Server Error")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]

        // GET: UserManage
        public IHttpActionResult GetListUser()
        {
            var model = new UserListModel();
            var listUser = UserManager.Users.ToList();
            Mapper.Map(listUser, model.UserList);
            return Json(model);

        }


        //[Route("id")]
        //[SwaggerResponse(200, "Returns the result of update a User", typeof(ApiJsonResult))]
        //[SwaggerResponse(500, "Internal Server Error")]
        //[SwaggerResponse(400, "Bad Request")]
        //[SwaggerResponse(401, "Not Authorizated")]
        //[HttpPut]
        //public IHttpActionResult Update(UserEditModel model)
        //{
        //    var res = new ApiJsonResult();

        //    try
        //    {
              
        //        //Get User by identity
        //        var user = UserManager.Users.FirstOrDefault(x=>x.Id == model.Id);
        //        if (user == null)
        //        {
        //            res.ErrorMessages.Add("User is not found.");
        //            return Json(res);
        //        }

        //        //Update User
        //        Mapper.Map(model, user);

        //        //update
        //        //UserManager.Users();
        //        UserManager.Update(user);
               

        //        return new HttpApiActionResult(HttpStatusCode.OK, res);
        //    }
        //    catch (Exception ex)
        //    {
        //        res.ErrorMessages.Add(ex.Message);
        //        return new HttpApiActionResult(HttpStatusCode.BadRequest, res);
        //    }
        //}

    }
}