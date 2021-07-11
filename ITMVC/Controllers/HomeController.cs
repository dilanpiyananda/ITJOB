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
using ITMVC.Models;
using AutoMapper;

namespace ITMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDocumentDbService _dbDoc = new DocumentDbService();
        private readonly IJobPostService _jobPost = new JobPostService();
        private readonly ICategoryService _categorySerice = new CategoryService();

        public ActionResult Index()
        {
            string userUuid = HttpContext.User.Identity.GetUserId();
            HomeViewModel model = new HomeViewModel()
            {
                Categories = Mapper.Map<List<CategoryMM>>(_categorySerice.GetAllCategory()),
                CategoryDropDown = _categorySerice.DropDown()
            };
            return View(model);
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
                return Json(false);

            var result = (from JobMain jo in model
                          select new
                          {
                              JobMainId = jo.JobMainId,
                              Title = jo.Title,
                              Description = jo.Description,
                              CvAcceptEmail = jo.CvAcceptEmail,
                              NumberOfVacancy = jo.NumberOfVacancy,
                              JobTypes = ((JobType)jo.JobTypes).ToString(),
                              ComapnyLogo=jo.CompanyLogo.Count() > 0 ?(jo.CompanyLogo.Where(d => d.ResolutionType == (int)FileType._Medium).FirstOrDefault().virtualPath).Replace("~","..") : null,
                              NumberOfDays=Convert.ToInt32(( DateTime.Now - jo.OpenDate).TotalDays),
                              NumberOfExpire =Convert.ToInt32( ( jo.CloseDate-DateTime.Now).TotalDays)
                          }).ToList();
            return Json(result);
        }

        public ActionResult SerchJobGet(long skipCount,long categoryId,string searchKey)
        {
            var model = _jobPost.GetAllJob(DateTime.Now, skipCount,searchKey,categoryId);
            if (model == null)
                return Json(false);

            var result = (from JobMain jo in model
                          select new
                          {
                              JobMainId = jo.JobMainId,
                              Title = jo.Title,
                              Description = jo.Description,
                              CvAcceptEmail = jo.CvAcceptEmail,
                              NumberOfVacancy = jo.NumberOfVacancy,
                              JobTypes = ((JobType)jo.JobTypes).ToString(),
                              ComapnyLogo = jo.CompanyLogo.Count() > 0 ? (jo.CompanyLogo.Where(d => d.ResolutionType == (int)FileType._Medium).FirstOrDefault().virtualPath).Replace("~", "..") : null,
                              NumberOfDays = Convert.ToInt32((DateTime.Now - jo.OpenDate).TotalDays),
                              NumberOfExpire = Convert.ToInt32((jo.CloseDate - DateTime.Now).TotalDays)
                          }).ToList();
            return Json(result);
        }

        public ActionResult CategoryJob(long skipCount, long categoryId)
        {
            var model = _jobPost.GetAllJob(DateTime.Now, skipCount,categoryId);
            if (model == null)
                return Json(false);

            var result = (from JobMain jo in model
                          select new
                          {
                              JobMainId = jo.JobMainId,
                              Title = jo.Title,
                              Description = jo.Description,
                              CvAcceptEmail = jo.CvAcceptEmail,
                              NumberOfVacancy = jo.NumberOfVacancy,
                              JobTypes = ((JobType)jo.JobTypes).ToString(),
                              ComapnyLogo = jo.CompanyLogo.Count() > 0 ? (jo.CompanyLogo.Where(d => d.ResolutionType == (int)FileType._Medium).FirstOrDefault().virtualPath).Replace("~", "..") : null,
                              NumberOfDays = Convert.ToInt32((DateTime.Now - jo.OpenDate).TotalDays),
                              NumberOfExpire = Convert.ToInt32((jo.CloseDate - DateTime.Now).TotalDays)
                          }).ToList();
            return Json(result);
        }
    }
}