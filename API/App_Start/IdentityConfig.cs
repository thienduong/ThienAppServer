using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using API.Models;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.Owin.Security.Cookies;

namespace API
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        

        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            // Configure validation logic for usernames
            this.UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = Startup.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                this.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
        }

        //public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        //{
        //    var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
        //    // Configure validation logic for usernames
        //    manager.UserValidator = new UserValidator<ApplicationUser>(manager)
        //    {
        //        AllowOnlyAlphanumericUserNames = false,
        //        RequireUniqueEmail = true
        //    };
        //    // Configure validation logic for passwords
        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 6,
        //        RequireNonLetterOrDigit = true,
        //        RequireDigit = true,
        //        RequireLowercase = true,
        //        RequireUppercase = true,
        //    };
        //    var dataProtectionProvider = options.DataProtectionProvider;
        //    if (dataProtectionProvider != null)
        //    {
        //        manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
        //    }
        //    return manager;
        //}
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager, new CookieAuthenticationOptions().AuthenticationType);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        //override this method
        //authenticate from external authorization server
        //and create a claim
        //public override async Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        //{
        //    string uri = ConfigurationManager.AppSettings["baseURI"] + "token";
        //    string clientId = ConfigurationManager.AppSettings["clientId"];
        //    var jwtProvider = Providers.JwtProvider.Create(uri);
        //    string token = await jwtProvider.GetTokenAsync(userName, password, clientId, Environment.MachineName);
        //    if (token == null)
        //    {
        //        return SignInStatus.Failure;
        //    }
        //    else
        //    {
        //        //decode payload
        //        dynamic payload = jwtProvider.DecodePayload(token);
        //        //create an Identity Claim
        //        ClaimsIdentity claims = jwtProvider.CreateIdentity(true, userName, payload);

        //        //sign in
        //        var context = HttpContext.Current.Request.GetOwinContext();
        //        var authenticationManager = context.Authentication;
        //        authenticationManager.SignIn(claims);

        //        return SignInStatus.Success;
        //    }
        //}

    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
        : base(roleStore) { }

        public static ApplicationRoleManager Create(
            IdentityFactoryOptions<ApplicationRoleManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationRoleManager(
                new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
            return manager;
        }
    }
}
