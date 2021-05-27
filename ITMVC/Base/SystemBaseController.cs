using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ITMVC.Base
{
    public class SystemBaseController : Controller
    {
        protected string GetUserUuid()
        {
            return HttpContext.User.Identity.GetUserId();
        }
    }
}