using API.Core.Services;
using API.Framework;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNet.Identity.Owin;

namespace API.Controllers
{
    public class BaseApiController : ApiController
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        private Dictionary<string, object> _serviceList;
        private T GetService<T>() where T : class
        {
            if (_serviceList == null)
                _serviceList = new Dictionary<string, object>();
            var service = _serviceList.FirstOrDefault(s => s.Key == typeof(T).FullName);
            if (service.Key == null)
            {
                var sv = EngineContext.Resolver.Resolve<T>();
                _serviceList.Add(typeof(T).FullName, sv);
                return sv;
            }
            return (T)service.Value;
        }

        private ApplicationRoleManager _roleManager;

        protected ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set { _roleManager = value; }
        }

        #region Service
        protected IProductService _productService { get { return GetService<IProductService>(); } }
        #endregion
    }
}