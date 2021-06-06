using AutoMapper;
using ITCOMMON.Services.Class;
using ITCOMMON.Services.Interface;
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
    public class ManageJobController : SystemBaseController
    {
        private readonly IComapnyDataService _comapnyDetails = new ComapnyDataService();
        private readonly IDocumentService _documentService = new DocumentService();
        private readonly IAcceptEmailService _emailService = new AcceptEmailService();
        private readonly IJobPostService _jobService = new JobPostService();
        private readonly ICategoryService _CategoryService = new CategoryService();

        // GET: Company/MangeJob
        public ActionResult Index()
        {
            return PartialView("_ManageJob");
        }
        public PartialViewResult AllJobPartial(long companyId)
        {
            var model = Mapper.Map<List<JobMM>>(_jobService.GetJobbyCompanyId(companyId));
            return PartialView("_AllJobPartial",model);
        }

        public PartialViewResult PendingApprovalJobPartial(long companyId)
        {
            var model = Mapper.Map<List<JobMM>>(_jobService.GetJobbyCompanyId(companyId,Approval.pending));
            return PartialView("_AllJobPartial", model);
        }

        public PartialViewResult ApprovedJobPartial(long companyId)
        {
            var model = Mapper.Map<List<JobMM>>(_jobService.GetJobbyCompanyId(companyId, Approval.approved));
            return PartialView("_AllJobPartial", model);
        }

        public PartialViewResult RejectedJobPartial(long companyId)
        {
            var model = Mapper.Map<List<JobMM>>(_jobService.GetJobbyCompanyId(companyId, Approval.rejected));
            return PartialView("_AllJobPartial", model);
        }

        public PartialViewResult ShowScript()
        {
            return PartialView("_ManageJobScript");
        }
    }
}