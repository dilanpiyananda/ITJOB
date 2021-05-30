using AutoMapper;
using ITCOMMON.Services.Class;
using ITCOMMON.Services.Interface;
using ITDB.Domain;
using ITDB.Domain.Enum;
using ITMVC.Base;
using ITMVC.Models.JOBVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITMVC.Areas.Company.Controllers
{
    public class JobController : SystemBaseController
    {
        private readonly IComapnyDataService _comapnyDetails = new ComapnyDataService();
        private readonly IDocumentService _documentService = new DocumentService();
        private readonly IAcceptEmailService _emailService = new AcceptEmailService();
        private readonly IJobPostService _jobService = new JobPostService();
        private readonly ICategoryService _CategoryService = new CategoryService();
        // GET: Company/Job
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult JobScript()
        {
            return PartialView("_jobScript");
        }
        public PartialViewResult PostJob(long comapnyDetailsId,long JobId)
        {
            JobViewModel model = new JobViewModel();
            model.CompanyId = comapnyDetailsId;

            if (JobId > 0)
            {
                model.Job = Mapper.Map<JobMM>(_jobService.GetJob(JobId));                
            }
            else
            {
                model.Job = new JobMM() { JobTypes=JobType.FullTime};
            }
            dropDownSet(model);
            return PartialView("_PostJob",model);
        }

        public JsonResult SaveJob(JobViewModel model)
        {
            string error = null;
            long jobId = 0;
            if(model.Job.JobMainId == 0)
            {
                error = _jobService.JobSave(model.Job, GetUserUuid(), model.JobImage, model.CompanyId, out long jobsId);
                jobId = jobsId;
            }
            else
            {

            }
            CustomeJsonModel jsonModel = new CustomeJsonModel();
            if(error == null)
            {
                jsonModel.Error = null;
                jsonModel.IsSuccess = true;
                jsonModel.Id = jobId;
            }
            else
            {
                jsonModel.Error = error;
                jsonModel.IsSuccess = false;
                jsonModel.Id = 0;
            }

            return Json(jsonModel);
        }
        public void dropDownSet(JobViewModel model)
        {
            model.AcceptEmail = _emailService.DropDown(model.CompanyId);
            model.Category = _CategoryService.DropDown();
        }
    }
}