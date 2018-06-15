using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace API.Controllers
{
    public class BaseApiController : ApiController
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
    }
}