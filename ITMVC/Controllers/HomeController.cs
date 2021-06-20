using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using ITCOMMON.Services.Interface;
using ITCOMMON.Services.Class;
using ITDB.Domain.Job;
using ITDB.Domain.Enum;

namespace ITMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDocumentDbService _dbDoc = new DocumentDbService();
        private readonly IJobPostService _jobPost = new JobPostService();

        public ActionResult Index()
        {
            string userUuid = HttpContext.User.Identity.GetUserId();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult CompanyJob(long skipCount)
        {
            var model = _jobPost.GetAllJob(DateTime.Now,skipCount);
            if (model == null)
                return null;

            var result = (from JobMain jo in model
                          select new
                          {
                              JobMainId = jo.JobMainId,
                              Title = jo.Title,
                              Description = jo.Description,
                              CvAcceptEmail = jo.CvAcceptEmail,
                              NumberOfVacancy = jo.NumberOfVacancy,
                              JobTypes = jo.JobTypes,
                              ComapnyLogo=jo.CompanyLogo != null ? jo.CompanyLogo.Where(d => d.ResolutionType == (int)FileType._Medium).FirstOrDefault().virtualPath : null,
                              NumberOfDays=( DateTime.Now - jo.OpenDate),
                              NumberOfExpire = ( jo.CloseDate-DateTime.Now)

                          }).ToList();
            return Json(result);
        }
    }
}