using API.Framework;
using API.Models;
using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API
{
    /// <summary>
    /// Test module service registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Order loading
        /// </summary>
        public int Order
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// Register services here
        /// </summary>
        /// <param name="builder"></param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>();
            builder.RegisterType<UserManager<ApplicationUser>>();
            builder.RegisterType<ApplicationUserManager>();

            builder.RegisterType<RoleStore<IdentityRole, string, IdentityUserRole>>().As<IRoleStore<IdentityRole, string>>();
            builder.RegisterType<ApplicationRoleManager>();

            builder.RegisterType<ApplicationSignInManager>();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication);

        }
    }
}