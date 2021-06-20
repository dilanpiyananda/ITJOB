using ITCOMMON.Services.Interface;
using ITDB.Domain.Enum;
using ITDB.Domain.Job;
using ITDB.Repository.Class;
using ITDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCOMMON.Services.Class
{
    public class JobPostService: IJobPostService
    {
        private readonly IJobPostRepository _jobPostRepo = new JobPostRepository();
        private readonly ICompanyHasJobService _compnyHasJobService = new CompanyHasJobService();
        private readonly IComapnyDataService _compnyDataService = new ComapnyDataService();
        private readonly IDocumentService _documentService = new DocumentService();
        private readonly IDocumentDbService _documentDbService = new DocumentDbService();
        private readonly IGlobleNoteService _globleNoteService = new GlobleNoteService();
        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public JobMain GetJob(long JobId)
        {
            return _jobPostRepo.GetJob(JobId);
        }
        /// <summary>
        /// Get All Job
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetAllJob()
        {
            var job = _jobPostRepo.GetAllJob();
            foreach(var a in job)
            {
                a.DocumentData = _documentDbService.GetDocument(a.JobMainId);
                long companyId = _compnyHasJobService.GetCompanyId(a.JobMainId);
                a.CompanyDetails = _compnyDataService.GetCompanyDetailsByCompanyId(companyId);
                a.CompanyLogo = _documentDbService.GetDocument(companyId);
            }
            return job;
        }
        /// <summary>
        /// Get All Job
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetAllJob(DateTime startTime, long skipCount)
        {
            var jobs= _jobPostRepo.GetAllJob(startTime,skipCount);
            if (jobs == null)
                return null;

            foreach (var a in jobs)
            {
                a.DocumentData = _documentDbService.GetDocument(a.JobMainId);
                long companyId = _compnyHasJobService.GetCompanyId(a.JobMainId);
                a.CompanyDetails = _compnyDataService.GetCompanyDetailsByCompanyId(companyId);
                a.CompanyLogo = _documentDbService.GetDocument(companyId);
            }
            return jobs;
        }
        /// <summary>
        /// Save job
        /// </summary>
        /// <returns></returns>
        public string JobSave(JobMain job, string userUuid, HttpPostedFileBase JobImage, long companyId, out long JobsId)
        {
            string error = _jobPostRepo.JobSave(job, userUuid, out long jobId);
            if (error != null)
            {
                JobsId = 0;
                return error;
            }

            JobsId = jobId;

            CompanyHasJob cojob = new CompanyHasJob()
            {
                JobMainId = jobId,
                CompanyId = companyId,
            };

            error = _compnyHasJobService.Save(cojob,userUuid);
            if(error != null)
            {
                return error;
            }

            if(JobImage != null)
            {
                error = _documentService.UploadImage(JobImage, Section.Job, userUuid, jobId);
            }

            return error;
        }
        /// <summary>
        /// Update job
        /// </summary>
        /// <returns></returns>
        public string Update(JobMain job, string userUuid, HttpPostedFileBase JobImage, long companyId)
        {
            string error = _jobPostRepo.Update(job, userUuid);
            if (error != null)
                return error;

            if (JobImage != null)
            {
                error = _documentService.UploadImage(JobImage, Section.Job, userUuid, job.JobMainId);
            }

            return error;
        }

        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetJobbyCompanyId(long comapnyId)
        {
            long[] jobId = _compnyHasJobService.GetComapnyHasJob(comapnyId);

            if (jobId == null)
                return null;
            else
                return _jobPostRepo.GetJobbyCompanyId(jobId);
        }

        /// <summary>
        /// Get Job using job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public List<JobMain> GetJobbyCompanyId(long comapnyId, Approval aproval)
        {
            long[] jobId = _compnyHasJobService.GetComapnyHasJob(comapnyId);

            if (jobId == null)
                return null;
            else
                return _jobPostRepo.GetJobbyCompanyId(jobId, aproval);
        }

        /// <summary>
        /// Delete job
        /// </summary>
        /// <returns></returns>
        public string Delete(long jobId)
        {
            string error = _jobPostRepo.Delete(jobId);

            if (error == null)
                return error;

            error = _globleNoteService.DeleteGlobleNote(Section.Job, jobId);
            error = _compnyHasJobService.deleteCompanyHasJobByJobId(jobId);

            return error;
        }

    }
}