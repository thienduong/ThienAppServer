using API.Framework;
using AutoMapper;
using FluentValidation;
using FluentValidation.Attributes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Users
{
    
    
    #region Models
    public class UserModel
    {


      
     
        public string Id { get; set; }
    
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool AccessFailedCount { get; set; }
        public string UserName { get; set; }
    }
    public class UserListModel : ApiJsonResult
    {
     
        public UserListModel()
        {
            UserList = new List<UserModel>();
        }
        public List<UserModel> UserList { get; set; }
    }
    //[Validator(typeof(UserEditValidator))]
    //public class UserEditModel
    //{
    //    public string Id { get; set; }

    //    public string Email { get; set; }
    //    public bool EmailConfirmed { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public bool PhoneNumberConfirmed { get; set; }
    //    public bool AccessFailedCount { get; set; }
    //    public string UserName { get; set; }

    //}


    //#region Validators

    ///// <summary>
    ///// Validate for UserEditModel
    ///// </summary>
    //public class UserEditValidator : AbstractValidator<UserEditModel>
    //{
    //    /// <summary>
    //    /// Define validators here
    //    /// </summary>
    //    public UserEditValidator()
    //    {

    //    }
    //}

    #endregion

    #region Mappings


    public class MapperRegistrar : IMapperRegistrar
    {
        public int Order
        {
            get
            {
                return 1;
            }
        }

        public void Register(IMapperConfigurationExpression config)
        {

        config.CreateMap<IdentityUser, UserModel>();
         
        }
    }

    #endregion

   
}
