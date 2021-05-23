using ITMVC.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ITCOMMON.Services.Interface;
using ITCOMMON.Services.Class;
using ITMVC.Models.ComapnyVM;
using ITDB.Domain.Enum;
using ITDB.Domain;
using ITMVC.Models;

namespace ITMVC.Areas.Company.Controllers
{
    public class CompanyController : SystemBaseController
    {
        private readonly IComapnyDataService _comapnyDetails = new ComapnyDataService();
        private readonly IDocumentService _documentService = new DocumentService();
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
                var model = GetCompanyDetails(userUuid);


                return PartialView("_MainCompany", model);
            }
            return null;
        }

        /// <summary>
        /// Save update company Details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult CompanyMainDetialsSave(CompanyViewModel model)
        {
            string error = null;
            if (model.Company.CompanyDetailsId == 0)
            {
                error = _comapnyDetails.Save(HttpContext.User.Identity.GetUserId(), model.Company, model.CompanyLogo, out int comapanyDetailsId);
            }
            else{
                error = _comapnyDetails.Update(HttpContext.User.Identity.GetUserId(), model.Company, model.CompanyLogo);
            }
            
            if(error == null)
            {
                model = GetCompanyDetails(HttpContext.User.Identity.GetUserId());
                return PartialView("_MainCompany", model);
            }
            else
            {
                return null;
            }
            
        }

        private CompanyViewModel GetCompanyDetails(string userUuid)
        {
            CompanyViewModel model = new CompanyViewModel()
            {
                Company = _comapnyDetails.GetCompanyDetails(userUuid),
            };
            return model;
        }

        public JsonResult UploadImage(CompanyViewModel model)
        {
            long compnyDetailsId = 0;
            CommonPassData modelcommon = new CommonPassData()
            {
                IsUse = false,
            };

            if (model.Company.CompanyDetailsId < 1)
            {
                CompanyDom company = new CompanyDom()
                {
                    CompanyDetailsId = 0,
                    CompanyName = "",
                    UserId = HttpContext.User.Identity.GetUserId(),
                    ContactNo = "",
                    TrustedId = (int)TrustEnum.NotDeside,
                };
               string errorSave = _comapnyDetails.Save(HttpContext.User.Identity.GetUserId(), company, model.CompanyLogo, out int comapanyDetailsId);
                compnyDetailsId = comapanyDetailsId;
                modelcommon.IsUse = true;
                modelcommon.id = comapanyDetailsId;
            }

            modelcommon.error = _documentService.UploadImage(model.CompanyLogo, Section.company, HttpContext.User.Identity.GetUserId(),model.Company.CompanyDetailsId ==0? compnyDetailsId: model.Company.CompanyDetailsId);
            return Json(modelcommon);
        }
    }
}