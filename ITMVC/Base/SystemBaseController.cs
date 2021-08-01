using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITCOMMON.Services.Class;
using ITCOMMON.Services.Interface;
using ITDB.Domain.Enum;
using Microsoft.AspNet.Identity;

namespace ITMVC.Base
{
    public class SystemBaseController : Controller
    {
        private readonly IRoleMenualService _roleService = new RoleMenualService();

        protected string GetUserUuid()
        {
            return HttpContext.User.Identity.GetUserId();
        }

        public ActionResult RedirectPageComapareUser()
        {

           string roleName = _roleService.GetRolebyUserId(GetUserUuid());


            if (roleName == RoleDetails.Admin.ToString())
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else if (roleName == RoleDetails.Company.ToString())
            {
                return RedirectToAction("Index", "Company", new { area = "Company" });
            }
            else if (roleName == RoleDetails.User.ToString())
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

    }
}