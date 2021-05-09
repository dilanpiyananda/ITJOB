using ITMVC.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ITCOMMON.Services.Repository;
using ITCOMMON.Services.Class;
using ITMVC.Models.ComapnyVM;

namespace ITMVC.Areas.Company.Controllers
{
    public class CompanyController : SystemBaseController
    {
        private readonly IComapnyDataService _comapnyDetails = new ComapnyDataService();
        // GET: Company/Company
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult CompanyMainDetials()
        {
            string userUuid = HttpContext.User.Identity.GetUserId();

            if(userUuid != null)
            {
                CompanyViewModel model = new CompanyViewModel()
                {
                    Company = _comapnyDetails.GetCompanyDetails(userUuid),
                };
                
                return PartialView("_MainCompany", model);
            }
            return null;
        }

        /// <summary>
        /// Save update company Details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult CompanyMainDetials(CompanyViewModel model)
        {
            string error = _comapnyDetails.Save(HttpContext.User.Identity.GetUserId(), model.Company, model.CompanyLogo, out int comapanyDetailsId);
            if(error == null)
            {

            }
            model.Company.CompanyDetailsId = comapanyDetailsId;
            return PartialView("_MainCompany", model);
        }
    }
}